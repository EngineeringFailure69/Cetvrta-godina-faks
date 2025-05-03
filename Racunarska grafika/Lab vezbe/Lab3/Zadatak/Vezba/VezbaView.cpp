
// VezbaView.cpp : implementation of the CVezbaView class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Vezba.h"
#endif

#include "VezbaDoc.h"
#include "VezbaView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CVezbaView

IMPLEMENT_DYNCREATE(CVezbaView, CView)

BEGIN_MESSAGE_MAP(CVezbaView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CVezbaView construction/destruction

// Ucitavamo sve puzle

CVezbaView::CVezbaView() noexcept
{
	LoadPuzzlePieces();
}

CVezbaView::~CVezbaView()
{
	for (int i = 0; i < MAX_PIECES; i++) {
		delete puzzlePieces[i];
	}
}

BOOL CVezbaView::PreCreateWindow(CREATESTRUCT& cs)
{
	return CView::PreCreateWindow(cs);
}

/// lab

void CVezbaView::LoadPuzzlePieces()
{
	// ucitavamo deo po deo slagalice pomocu DImage f-je Load

	char s[] = "1.bmp";
	for (int i = 0; i < MAX_PIECES; i++) {
		s[0] = '0' + (i + 1);
		puzzlePieces[i] = new DImage();
		puzzlePieces[i]->Load(CString(s));
	}
}

void CVezbaView::DrawTransparent(CDC* pDC, DImage* img, bool isBlue) {

	int w = img->Width();
	int h = img->Height();

	CBitmap srcBitmap;
	srcBitmap.CreateCompatibleBitmap(pDC, w, h);

	CBitmap maskBitmap;
	maskBitmap.CreateBitmap(w, h, 1, 1, nullptr); // monohromatska bitmapa (crno-bela)

	CDC* srcDC = new CDC(); // src memorijski DC
	srcDC->CreateCompatibleDC(pDC);

	CDC* dstDC = new CDC(); // dst memorijski DC
	dstDC->CreateCompatibleDC(dstDC);

	CBitmap* oldSrcBitmap = srcDC->SelectObject(&srcBitmap);
	CBitmap* oldDstBitmap = dstDC->SelectObject(&maskBitmap);

	//pravi src i dest CRect koji ce da crta puzzlePieces pojedinacno u srcDC
	img->Draw(srcDC, CRect(0, 0, w, h), CRect(0, 0, w, h));
	// deo puzzle koji je plav
	if (isBlue)
		makeBlue(&srcBitmap);
	else
		makeGray(&srcBitmap);

	// sad je svaki deo puzle ili sive ili plave boje ali ima pozadinu
	// sada uklanjamo pozadinu postupkom sa slajdova

	// 1 korak - kopiramo RGB bitmapu na monohromatsku -> pozadina bela (1), objekat crn (0)

	COLORREF trColor = srcDC->GetPixel(0, 0); // uzimamo piksel 0,0
	COLORREF oldBgColor = srcDC->SetBkColor(trColor); // stavljamo pozadinu na boju piksela 0,0

	dstDC->BitBlt(0, 0, w, h, srcDC, 0, 0, SRCCOPY);

	// 2 korak - vrsimo AND operaciju, pri cemu je sad objekat RGB, a pozadina crna

	// za novi srcDC, pozadina ce se tretirati kao crna boja (0), objekat kao bela (1)
	COLORREF oldTextColorSrc = srcDC->SetTextColor(RGB(255, 255, 255));
	COLORREF oldBackgroundColorSrc = srcDC->SetBkColor(RGB(0, 0, 0));

	srcDC->BitBlt(0, 0, w, h, dstDC, 0, 0, SRCAND);

	Translate(pDC, -w / 2, -h / 2); // pomeramo koordinatni pocetak u centar slike

	pDC->BitBlt(0, 0, w, h, dstDC, 0, 0, SRCAND); // u pDC - pozadina ce biti bele boje, objekat crne

	pDC->BitBlt(0, 0, w, h, srcDC, 0, 0, SRCPAINT); // "lepimo" srcDC preko pDC

	Translate(pDC, w / 2, h / 2); // vracamo koordinatni pocetak u prethodni polozaj

	srcDC->SetTextColor(oldTextColorSrc);
	srcDC->SetBkColor(oldBgColor);

	srcDC->SelectObject(oldSrcBitmap);
	dstDC->SelectObject(oldDstBitmap);

	srcDC->DeleteDC();
	delete srcDC;

	dstDC->DeleteDC();
	delete dstDC;
}
void CVezbaView::makeGray(CBitmap* bitmap) {
	BITMAP b;
	bitmap->GetBitmap(&b);

	BYTE* bits = new BYTE[b.bmWidthBytes * b.bmHeight];
	bitmap->GetBitmapBits(b.bmWidthBytes * b.bmHeight, bits);
	COLORREF trColor = RGB(bits[2], bits[1], bits[0]);

	for (int i = 0; i < b.bmWidthBytes * b.bmHeight; i += 4)
	{
		if (RGB(bits[i + 2], bits[i + 1], bits[i]) == trColor) continue;
		BYTE gr = min(255, (bits[i] + bits[i + 1] + bits[i + 2]) / 3 + 64);
		bits[i] = bits[i + 1] = bits[i + 2] = gr;
	}

	bitmap->SetBitmapBits(b.bmWidthBytes * b.bmHeight, bits);

	if (bits)
		delete[] bits;

	bits = nullptr;
}
void CVezbaView::makeBlue(CBitmap* bitmap) {

	BITMAP b;
	bitmap->GetBitmap(&b); // u promenljivoj b dobijamo informacije o izvornoj bitmapi

	// bmWidthBytes - svaka scan-linija (vrsta u bitmapi) mora imati dužinu koja je celobrojni umnožak 32 bita 
	// pr. 4,8,12,16... u jednom redu * visina = matrica piksela
	BYTE* bits = new BYTE[b.bmWidthBytes * b.bmHeight]; // niz vrednosti
	bitmap->GetBitmapBits(b.bmWidthBytes * b.bmHeight, bits);

	// uzimamo vr. prvog piksela koji ce da bude pozadina
	COLORREF trColor = RGB(bits[2], bits[1], bits[0]);

	for (int i = 0; i < b.bmWidthBytes * b.bmHeight; i += 4) {
		if (RGB(bits[i + 2], bits[i + 1], bits[i]) == trColor) continue;
		// max(gr) = 255, if bits[i] > gr => bits[i] = 255 else bits[i] = gr
		BYTE gr = min(255, (bits[i] + bits[i + 1] + bits[i + 2]) / 3 + 64);
		bits[i+2] = gr;
		bits[i + 1] = bits[i] = 0; // B,G,R - 2 preostala kanala se setuju na 0
	}

	bitmap->SetBitmapBits(b.bmWidthBytes * b.bmHeight, bits);

	if (bits)
		delete[] bits;

	bits = nullptr;
}

void CVezbaView::DrawGrid(CDC* pDC)
{
	CPen pen(PS_SOLID, 2, RGB(229, 229, 229));
	CPen* old = pDC->SelectObject(&pen);

	for (int i = 0; i <= 500; i += 25)
	{
		pDC->MoveTo(0, i);
		pDC->LineTo(500, i);

		pDC->MoveTo(i, 0);
		pDC->LineTo(i, 500);
	}
	pDC->SelectObject(old);
}

void CVezbaView::DrawBackground(COLORREF backgroundColor, CDC* pDC)
{
	CBrush brush(backgroundColor);
	CRect client;
	GetClientRect(&client);

	pDC->FillRect(client, &brush);
}

void CVezbaView::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM form = { 1, 0, 0, 1, dx, dy };
	pDC->ModifyWorldTransform(&form, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CVezbaView::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM form = { sx, 0, 0, sy, 0, 0 };
	pDC->ModifyWorldTransform(&form, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CVezbaView::Mirror(CDC* pDC, bool mx, bool my, bool rightMyltiply)
{
	Scale(pDC, mx ? -1 : 1, my ? -1 : 1, rightMyltiply);
}

void CVezbaView::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	float sindeg = sin(angle);
	float cosdeg = cos(angle);
	XFORM form = { cosdeg, sindeg, -sindeg, cosdeg, 0, 0 };
	pDC->ModifyWorldTransform(&form, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CVezbaView::DrawMem(CDC* pDC)
{
	DrawBackground(RGB(255, 255, 255), pDC); // bojimo pozadinu u belo
	DrawGrid(pDC); // crtamo grid

	XFORM tr;
	pDC->GetWorldTransform(&tr);

	// 0,0

	Translate(pDC,106,96);
	Rotate(pDC, PI/2+RAD(0.8));
	Mirror(pDC, true, false);
	DrawTransparent(pDC, puzzlePieces[0], false);
	pDC->SetWorldTransform(&tr);

	// 0,1

	Translate(pDC, 245, 90);
	Rotate(pDC, -PI / 20+RAD(8));
	Mirror(pDC, true, false);
	DrawTransparent(pDC, puzzlePieces[5], false);
	pDC->SetWorldTransform(&tr);

	// 0,2

	Translate(pDC, 404, 90);
	Rotate(pDC, PI / 4 +RAD(3));
	Mirror(pDC, true, false);
	DrawTransparent(pDC, puzzlePieces[4], false);
	pDC->SetWorldTransform(&tr);

	//// 1,0

	Translate(pDC, 104, 256);
	Rotate(pDC, -PI /18-RAD(10));
	Mirror(pDC, false, true);
	DrawTransparent(pDC, puzzlePieces[8], true);
	pDC->SetWorldTransform(&tr);

	//// 1,1

	Translate(pDC, 255, 253);
	//Rotate(pDC, -PI / 3 + RAD(2));
	Rotate(pDC, PI-RAD(36));
	Mirror(pDC, true, false);
	DrawTransparent(pDC, puzzlePieces[1], false);
	pDC->SetWorldTransform(&tr);

	//// 1,2

	Translate(pDC, 394, 242);
	Rotate(pDC, -PI / 6+RAD(10));
	Mirror(pDC, true, false);
	DrawTransparent(pDC, puzzlePieces[2], false);
	pDC->SetWorldTransform(&tr);

	//// 2,0

	Translate(pDC, 101, 409);
	Rotate(pDC, -PI/90);
	Mirror(pDC, false, true);
	DrawTransparent(pDC, puzzlePieces[3], false);
	pDC->SetWorldTransform(&tr);

	//// 2,1

	Translate(pDC, 242, 402);
	Rotate(pDC, -PI / 2+RAD(5.5));
	Mirror(pDC, true,false);
	DrawTransparent(pDC, puzzlePieces[6], false);
	pDC->SetWorldTransform(&tr);

	//// 2,2

	Translate(pDC, 403, 391);
	Rotate(pDC, PI/4-RAD(7));
	Mirror(pDC, true, false);
	DrawTransparent(pDC, puzzlePieces[7], false);
	pDC->SetWorldTransform(&tr);

}


void CVezbaView::OnDraw(CDC* pDC)
{
	CVezbaDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	CRect rect;
	GetClientRect(&rect);

	int pDCmode = pDC->SetGraphicsMode(GM_ADVANCED);

	CDC* memDC = new CDC(); // kontekst koji sluzi za crtanje u memoriju
	memDC->CreateCompatibleDC(pDC);

	int memDCmode = memDC->SetGraphicsMode(GM_ADVANCED);

	CBitmap memBitmap; // cuva sliku u vidu piksela, sluzi za crtanje u memoriju
	memBitmap.CreateCompatibleBitmap(pDC, rect.Width(), rect.Height());
	CBitmap* old = memDC->SelectObject(&memBitmap);

	DrawMem(memDC);

	//Translate(pDC, 250, 250);
	//Rotate(pDC, rotation * PI / 2);
	//Mirror(pDC, mx, my);
	//Translate(pDC, -250, -250);

	pDC->BitBlt(0, 0, rect.Width(), rect.Height(), memDC, 0, 0, SRCCOPY);

	pDC->SetGraphicsMode(pDCmode);

	memDC->SetGraphicsMode(memDCmode);
	memDC->SelectObject(old);
	memDC->DeleteDC();
	delete memDC;
}

// CVezbaView printing

BOOL CVezbaView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CVezbaView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CVezbaView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CVezbaView diagnostics

#ifdef _DEBUG
void CVezbaView::AssertValid() const
{
	CView::AssertValid();
}

void CVezbaView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CVezbaDoc* CVezbaView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CVezbaDoc)));
	return (CVezbaDoc*)m_pDocument;
}
#endif //_DEBUG


// CVezbaView message handlers
