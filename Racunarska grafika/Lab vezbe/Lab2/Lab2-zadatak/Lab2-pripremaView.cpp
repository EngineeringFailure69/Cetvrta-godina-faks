
// Lab2-pripremaView.cpp : implementation of the CLab2pripremaView class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Lab2-priprema.h"
#endif

#include "Lab2-pripremaDoc.h"
#include "Lab2-pripremaView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define kvadrat 25
#define PI 3.14
bool spaceKliknut = false;


// CLab2pripremaView

IMPLEMENT_DYNCREATE(CLab2pripremaView, CView)

BEGIN_MESSAGE_MAP(CLab2pripremaView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_KEYDOWN()
END_MESSAGE_MAP()

// CLab2pripremaView construction/destruction

CLab2pripremaView::CLab2pripremaView() noexcept
{
	// TODO: add construction code here
	this->tamniDeo = GetEnhMetaFile(CString("cactus_part.emf"));
	this->svetliDeo = GetEnhMetaFile(CString("cactus_part_light.emf"));

	this->prviUgao = 0;
	this->drugiUgao = 0;
}

CLab2pripremaView::~CLab2pripremaView()
{
}

BOOL CLab2pripremaView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CLab2pripremaView drawing

void Pozadina(CDC* pDC)
{
	CPen* plavaOlovka = new CPen(PS_SOLID, 0, RGB(221, 221, 221));
	CBrush* plavaCetka = new CBrush(RGB(135, 206, 235));
	pDC->SelectObject(plavaOlovka);
	pDC->SelectObject(plavaCetka);
	pDC->Rectangle(0, 0, 500, 500);
}

void Grid(CDC* pDC) 
{
	CPen* gridOlovka = new CPen(PS_SOLID, 2, RGB(225, 255, 255));
	pDC->SelectObject(gridOlovka);
	for (int i = 0; i < 500; i += 25)
	{
		pDC->MoveTo(0, i);
		pDC->LineTo(500, i);

		pDC->MoveTo(i, 0);
		pDC->LineTo(i, 500);
	}
	delete gridOlovka;
}

void CLab2pripremaView::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transformation;
	transformation.eM11 = 1;
	transformation.eM12 = 0;
	transformation.eM21 = 0;
	transformation.eM22 = 1;
	transformation.eDx = dx;
	transformation.eDy = dy;
	if (rightMultiply)
		pDC->ModifyWorldTransform(&transformation, MWT_RIGHTMULTIPLY);
	else pDC->ModifyWorldTransform(&transformation, MWT_LEFTMULTIPLY);
}

void CLab2pripremaView::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transformation;
	transformation.eM11 = sx;
	transformation.eM12 = 0;
	transformation.eM21 = 0;
	transformation.eM22 = sy;
	transformation.eDx = 0;
	transformation.eDy = 0;
	if (rightMultiply)
		pDC->ModifyWorldTransform(&transformation, MWT_RIGHTMULTIPLY);
	else
		pDC->ModifyWorldTransform(&transformation, MWT_LEFTMULTIPLY); 
}

void CLab2pripremaView::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transformation;
	transformation.eM11 = cos(angle);
	transformation.eM12 = sin(angle);
	transformation.eM21 = -sin(angle);
	transformation.eM22 = cos(angle);
	transformation.eDx = 0;
	transformation.eDy = 0;

	if (rightMultiply)
		pDC->ModifyWorldTransform(&transformation, MWT_RIGHTMULTIPLY);
	else
		pDC->ModifyWorldTransform(&transformation, MWT_LEFTMULTIPLY); //odnosno odozdo na dole
}

void CLab2pripremaView::Saksija(CDC* pDC)
{
	CPen* olovkaSaksija = new CPen(PS_SOLID, 1, RGB(0, 0, 0));
	CBrush* cetkaSaksija = new CBrush(RGB(222, 148, 0));
	pDC->SelectObject(olovkaSaksija);
	pDC->SelectObject(cetkaSaksija);

	CPoint donjiDeoSaksije[] = { CPoint(2*kvadrat, 8*kvadrat), CPoint(2*kvadrat, 12*kvadrat), CPoint(0*kvadrat, 11.5*kvadrat), CPoint(0*kvadrat, 8.5*kvadrat) };
	pDC->Rectangle(2.8 * kvadrat, 7.5 * kvadrat, 2 * kvadrat, 12.5 * kvadrat);
	pDC->Polygon(donjiDeoSaksije, 4);
}

void CLab2pripremaView::Kaktus(CDC* pDC)
{
	int prevMode = SetGraphicsMode(pDC->m_hDC, GM_ADVANCED); // prvo setujemo graficki mod
	XFORM XformOld;
	pDC->GetWorldTransform(&XformOld);

	Translate(pDC, 3 * kvadrat, 10 * kvadrat, false);
	Rotate(pDC, prviUgao, false);
	Scale(pDC, 2.0f, 2.0f, false);
	Rotate(pDC, PI / 2, false);
	pDC->PlayMetaFile(this->svetliDeo, CRect(-15, 0, 15, -37.5));
	Scale(pDC, 0.5f, 0.5f, false); // Ova scale funkcija resetuje proslu scale funkciju, odnosno, kada se odradi scale sa 2.0f, uzima se 
	//kolicnik 1/2, dobija se 0.5, i uradi se scale na tu vrednost da bi se prikupljene vrednosti u matrici ponistile, 1 se uvek deli sa 
	//vrednoscu iz druge scale funkcije
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);
	Rotate(pDC, -PI / 2, false);

	Scale(pDC, 0.5f, 0.5f, false);
	Translate(pDC, 3 * kvadrat, 0, false);
	Scale(pDC, 2.0f, 2.0f, false);
	Rotate(pDC, 3*PI / 4, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-6, 0, 6, -37.5));
	Rotate(pDC, -PI / 4, false);
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-6, 0, 6, -37.5));
	Rotate(pDC, -PI / 4, false);
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-6, 0, 6, -37.5));
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);
	Rotate(pDC, -PI / 4, false);

	Scale(pDC, 0.5f, 0.5f, false);
	Translate(pDC, 3 * kvadrat, 0, false);
	Rotate(pDC, -PI / 2, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-15, 0, 15, 37.5));
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);
	Rotate(pDC, PI / 2, false);

	Scale(pDC, 0.5f, 0.5f, false);
	Translate(pDC, 3 * kvadrat, 0, false);
	Rotate(pDC, -PI / 2, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-15, 0, 15, 37.5));
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);
	Rotate(pDC, PI / 2, false);

	Scale(pDC, 0.5f, 0.5f, false);
	Translate(pDC,-4 * kvadrat, -2 * kvadrat, false);
	Rotate(pDC, -PI / 2, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-6, 0, 6, 37.5));
	Rotate(pDC, -2*PI / 4, false);
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-6, 0, 6, 37.5));
	Rotate(pDC, PI / 4, false);
	Rotate(pDC, this->drugiUgao, false);
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->svetliDeo, CRect(-6, 0, 6, 37.5));
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);
	Rotate(pDC, 3*PI / 4-drugiUgao, false);

	Scale(pDC, 0.5f, 0.5f, false);
	Translate(pDC, 0, -3 * kvadrat, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-15, 0, 15, -37.5));
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);

	Scale(pDC, 0.5f, 0.5f, false);
	Translate(pDC, 3 * kvadrat, 3 * kvadrat, false);
	Rotate(pDC, PI/2, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->tamniDeo, CRect(-15, 0, 15, -37.5));
	Scale(pDC, 0.5f, 0.5f, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);
	Rotate(pDC, -PI / 2, false);

	Translate(pDC, 10 * kvadrat, 17 * kvadrat, false);
	Rotate(pDC, prviUgao, false);
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->PlayMetaFile(this->svetliDeo, CRect(-15, 0, 15, -37.5));
	Scale(pDC, 0.5f, 0.5f, false); // Ova scale funkcija resetuje proslu scale funkciju, odnosno, kada se odradi scale sa 2.0f, uzima se 
	//kolicnik 1/2, dobija se 0.5, i uradi se scale na tu vrednost da bi se prikupljene vrednosti u matrici ponistile, 1 se uvek deli sa 
	//vrednoscu iz druge scale funkcije
	Scale(pDC, 2.0f, 2.0f, false);
	pDC->Ellipse(-5, -5, 5, 5);

	pDC->SetWorldTransform(&XformOld); // vraca koordinatni pocetak gde je bio pre transformacije
	pDC->SetGraphicsMode(prevMode);
}

void CLab2pripremaView::OnDraw(CDC* pDC)
{
	CLab2pripremaDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	CRect drawRect(0, 0, 20 * kvadrat, 20 * kvadrat);
	pDC->IntersectClipRect(&drawRect);

	// TODO: add draw code for native data here
	// OLOVKE

	CPen* pozadinskaOlovka = new CPen(PS_SOLID, 0, RGB(221, 221, 221));
	CPen* kaktusOlovka = new CPen(PS_SOLID, 1, RGB(0, 0, 0));

	// CETKE

	CBrush* pozadinskaCetka = new CBrush(RGB(135, 206, 235));
	CBrush* kaktusCetka = new CBrush(RGB(0, 204, 0));


	CPen* staraOlovka = pDC->SelectObject(pozadinskaOlovka);
	CBrush* staraCetka = pDC->SelectObject(pozadinskaCetka);
	Pozadina(pDC);

	pDC->SelectObject(kaktusOlovka);
	pDC->SelectObject(kaktusCetka);
	Kaktus(pDC);
	Saksija(pDC);
	if (spaceKliknut)
		Grid(pDC);
	pDC->SelectObject(staraOlovka);
	pDC->SelectObject(staraCetka);

	delete pozadinskaCetka;
	delete pozadinskaOlovka;
	delete kaktusCetka;
	delete kaktusOlovka;
}


// CLab2pripremaView printing

BOOL CLab2pripremaView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CLab2pripremaView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CLab2pripremaView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CLab2pripremaView diagnostics

#ifdef _DEBUG
void CLab2pripremaView::AssertValid() const
{
	CView::AssertValid();
}

void CLab2pripremaView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CLab2pripremaDoc* CLab2pripremaView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CLab2pripremaDoc)));
	return (CLab2pripremaDoc*)m_pDocument;
}
#endif //_DEBUG


// CLab2pripremaView message handlers


void CLab2pripremaView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	// TODO: Add your message handler code here and/or call default

	CDC* pDC = GetDC();
	if (nChar == VK_SPACE && !spaceKliknut) {
		Grid(pDC);
		spaceKliknut = true;
	}
	else if (nChar == VK_SPACE && spaceKliknut)
	{
		spaceKliknut = false;
		Invalidate();
	}

	if (nChar == VK_LEFT) 
	{
		this->prviUgao -= PI / 6;
		Invalidate();
	}
	if (nChar == VK_RIGHT) 
	{
		this->prviUgao += PI / 16;
		Invalidate();
	}
	if (nChar == 'D') 
	{
		this->drugiUgao += PI / 6;
		Invalidate();
	}
	if (nChar == 'A') 
	{
		this->drugiUgao -= PI / 16;
		Invalidate();
	}
	if (nChar == 'F') 
	{
		this->prviUgao -= PI / 16;
		this->drugiUgao += PI / 16;
		Invalidate();
	}
	CView::OnKeyDown(nChar, nRepCnt, nFlags);
}
