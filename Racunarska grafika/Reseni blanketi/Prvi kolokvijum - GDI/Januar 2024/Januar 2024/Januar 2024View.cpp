
// Januar 2024View.cpp : implementation of the CJanuar2024View class
//

#include "pch.h"
#include "framework.h"
#include<math.h>
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Januar 2024.h"
#endif

#include "Januar 2024Doc.h"
#include "Januar 2024View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define PI 3.1415

// CJanuar2024View

IMPLEMENT_DYNCREATE(CJanuar2024View, CView)

BEGIN_MESSAGE_MAP(CJanuar2024View, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CJanuar2024View construction/destruction

CJanuar2024View::CJanuar2024View() noexcept
{
	// TODO: add construction code here

}

CJanuar2024View::~CJanuar2024View()
{
}

BOOL CJanuar2024View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CJanuar2024View drawing

void CJanuar2024View::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transform = { 1,0,0,1,dx,dy };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CJanuar2024View::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transform = { sx, 0, 0, sy, 0, 0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CJanuar2024View::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transform = { cos(angle), sin(angle),-sin(angle),cos(angle) };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CJanuar2024View::DrawPetal(CDC* pDC, CRect rect, COLORREF clrFill, COLORREF clrLine)
{
	CPen* olovkaLinija = new CPen(PS_SOLID, 1, clrLine);
	CBrush* cetkicaIspune = new CBrush(clrFill);
	CPen* staraOlovka = pDC->SelectObject(olovkaLinija);
	CBrush* staraCetkica = pDC->SelectObject(cetkicaIspune);


	int startX = rect.left;
	int startY = rect.bottom;
	pDC->MoveTo(startX, startY);
	pDC->BeginPath();
	pDC->LineTo(CPoint(startX, startY - (rect.Height()/20)));
	pDC->LineTo(CPoint(startY - (rect.Height()/20), rect.top));
	pDC->LineTo(CPoint(startX + (rect.Width() / 20), startY));
	pDC->LineTo(CPoint(startX, startY));
	pDC->EndPath();
	pDC->StrokeAndFillPath();

	pDC->MoveTo(rect.right - rect.Width() / 2, rect.bottom - rect.Height() / 2);
	pDC->BeginPath();
	pDC->LineTo(rect.right - rect.Width() / 2 - 2, rect.top);
	pDC->LineTo(rect.right - rect.Width() / 2 + (rect.Width() / 20) + 2, rect.top);
	pDC->LineTo(rect.right - rect.Width() / 2, rect.bottom - rect.Height() / 2);
	pDC->EndPath();
	pDC->StrokeAndFillPath();

	pDC->MoveTo(rect.right - rect.Width() / 2, rect.bottom - rect.Height() / 2 - 5);
	pDC->BeginPath();
	pDC->LineTo(rect.right, rect.bottom - rect.Height() / 2 - 7);
	pDC->LineTo(rect.right, rect.bottom - rect.Height() / 2 - (rect.Height() / 20) + 7);
	pDC->LineTo(rect.right - rect.Width() / 2, rect.bottom - rect.Height() / 2 - 5);
	pDC->EndPath();
	pDC->StrokeAndFillPath();

	pDC->SelectObject(staraOlovka);
	pDC->SelectObject(staraCetkica);
	delete olovkaLinija;
	delete cetkicaIspune;
}

void CJanuar2024View::DrawSnowFlake(CDC* pDC, CRect rect, COLORREF clrFill, COLORREF clrLine, int nArcs, float dRot, CString str)
{
	int prevGraphicsMode = SetGraphicsMode(pDC->m_hDC, GM_ADVANCED);
	XFORM transOld;
	pDC->GetWorldTransform(&transOld);
	CRect rect2;
	GetClientRect(&rect2);
	//Crtanje n delova pahuljice
	double korak = 2 * PI / nArcs;
	for (int i = 0; i < nArcs; i++)
	{
		// Resetuj transformaciju na originalnu
		pDC->SetWorldTransform(&transOld);
		// Translacija na centar ekrana
		//Translate(pDC, (float)rect2.Width() / 2, (float)rect2.Height() / 2, false);
		Rotate(pDC, dRot, false);
		// Rotacija za ugao ove latice
		Rotate(pDC, i * korak, false);

		// Translacija gore da donji levi ugao latice bude u centru
		Translate(pDC, 0, -rect.Height(), false);

		// Nacrtaj latice
		DrawPetal(pDC, rect, clrFill, clrLine);
	}

	// Centar pahuljice
	pDC->SetWorldTransform(&transOld);
	CBrush* centarPahuljiceCetka = new CBrush(HS_DIAGCROSS, RGB(0, 0, 255));
	CBrush* staraCetka = pDC->SelectObject(centarPahuljiceCetka);
	int radius = 20;
	CRect rectCircle(-radius, -radius, radius, radius);
	pDC->Ellipse(&rectCircle);

	//Teskt
	CFont font;
	font.CreateFont(20, 0, 0, 0, FW_BOLD, 0, 0, 0, RUSSIAN_CHARSET, 0, 0, 0, 0, _T("Arial"));
	CFont* stariFont = pDC->SelectObject(&font);
	int stariBkMode = pDC->SetBkMode(TRANSPARENT); // Ovo je neophodno da mi centri pahuljica ne bi bili transparentni
	pDC->SetTextColor(RGB(0, 0, 0));

	int n = str.GetLength();
	double r = 1.5 * rect.Height();
	double pocetniUgao = 135.0 * PI / 180.0; //u radijanima je ugao, 135 stepeni je pocetni, pise u tekstu zadatka
	double krajnjiUgao = 45.0 * PI / 180.0; //45 stepeni je krajnji ugao 
	double korakTekst = (krajnjiUgao - pocetniUgao) / (n - 1); // n - 1 karaktera u stringu, korak se dobija tako sto se krajnji ugao oduzme
	double novoX = 0, novoY = 0;
	// od pocetnog do krajnjeg karaktera 
	for (int i = 0; i < n; i++) 
	{
		double ugao = pocetniUgao + i * korakTekst;

		pDC->SetWorldTransform(&transOld);

		// Translacija na centar pahuljice
		Translate(pDC, 0, 0, false);

		novoX = (double)(r * cos(ugao)); // Novo x na koje se pomeram
		novoY = (double)(r * sin(ugao)); // Novo y na koje se pomeram

		// Translacija na poziciju slova, ovo novo x i y su zapravo nove tacke koje dobijam i koje mi predstavljaju centar slova 
		Translate(pDC, novoX, novoY, false);

		// Rotacija tako da slovo stoji tangentno
		Rotate(pDC, ugao - PI / 2, false);

		// Ispis slova (slovo se crta u centru)
		CString s;
		s.Format(L"%c", str[i]);
		pDC->TextOut(0, 0, s);
	}

	pDC->SetBkMode(stariBkMode); // Vracam stari BkMode
	pDC->SelectObject(staraCetka);
	pDC->SelectObject(stariFont);
	pDC->SetWorldTransform(&transOld);
	pDC->SetGraphicsMode(prevGraphicsMode);
	delete centarPahuljiceCetka;
}

void CJanuar2024View::DrawSnowFlakes(CDC* pDC, CRect* aRect, COLORREF* aClrFill, COLORREF* sClrLine, int* anArcs, float* aRot, CString* aStr, CPoint* aPts)
{
	int brojPahuljica = 0;
	while (!(aPts[brojPahuljica].x == -1 && aPts[brojPahuljica].y == -1))
		brojPahuljica++;
	for (int i = 0; i < brojPahuljica; i++)
	{
		int prevGraphicsMode = SetGraphicsMode(pDC->m_hDC, GM_ADVANCED);
		XFORM transOld;
		pDC->GetWorldTransform(&transOld);

		Translate(pDC, aPts[i].x, aPts[i].y, false);
		DrawSnowFlake(pDC, *aRect, aClrFill[i], sClrLine[i], anArcs[i], aRot[i], aStr[i]);

		pDC->SetWorldTransform(&transOld);
		pDC->SetGraphicsMode(prevGraphicsMode);
	}
}

void CJanuar2024View::OnDraw(CDC* pDC)
{
	CJanuar2024Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;
	
	// TODO: add draw code for native data here
	CRect rect;
	GetClientRect(&rect);
	CString tekstovi[3] = { L"**GDI**", L"Grafika", L"Januar 2024" }; // Ovde treba cirilica, ali ja iskreno ne znam kako da to podesim u visual studio
	CPoint centri[4] = { CPoint(200, 200), CPoint(rect.Width()/2, 450), CPoint(1200, 200), CPoint(-1, -1)};
	CRect rectPahuljice(0, 0, 100, 100);
	COLORREF clrFills[3] = { RGB(0, 0, 255),RGB(255, 0, 0),RGB(0, 255, 0) };
	COLORREF clrLines[3] = { RGB(0, 0, 255),RGB(255, 0, 0),RGB(0, 255, 0) };
	int nArcs[3] = { 3, 6, 9 };
	float dRots[3] = { 0.0f, 45.0f, 75.0f };
	DrawSnowFlakes(pDC, &rectPahuljice, clrFills, clrLines, nArcs, dRots, tekstovi, centri);
}

// CJanuar2024View printing

BOOL CJanuar2024View::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CJanuar2024View::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CJanuar2024View::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CJanuar2024View diagnostics

#ifdef _DEBUG
void CJanuar2024View::AssertValid() const
{
	CView::AssertValid();
}

void CJanuar2024View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CJanuar2024Doc* CJanuar2024View::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CJanuar2024Doc)));
	return (CJanuar2024Doc*)m_pDocument;
}
#endif //_DEBUG


// CJanuar2024View message handlers
