
// Lab1-pripremaView.cpp : implementation of the CLab1pripremaView class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Lab1-priprema.h"
#endif

#include "Lab1-pripremaDoc.h"
#include "Lab1-pripremaView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define kvadrat 25


// CLab1pripremaView

IMPLEMENT_DYNCREATE(CLab1pripremaView, CView)

BEGIN_MESSAGE_MAP(CLab1pripremaView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_KEYDOWN()
END_MESSAGE_MAP()

// CLab1pripremaView construction/destruction

CLab1pripremaView::CLab1pripremaView() noexcept
{
	// TODO: add construction code here

}

CLab1pripremaView::~CLab1pripremaView()
{
}

BOOL CLab1pripremaView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

void CLab1pripremaView::DrawRegularPolygon(CDC* pDC, int cx, int cy, int r, int n, float rotAngle)
{
	float alfa = 2 * 3.14 / n; // pomeraj temena
	float stepen = 0;
	int i = 0;
	float rotacija = rotAngle * 3.14 / 180; // prevodjenje iz stepena u radijan
	CPoint* nizTemenaMnogougla = new CPoint[n];
	while (stepen < 2 * 3.14)
	{
		nizTemenaMnogougla[i++] = CPoint(r * cos(stepen + rotacija) + cx, r * sin(stepen + rotacija) + cy); // +rotacija ukoliko zelimo da celo telo rotiramo
		stepen += alfa;
	}
	pDC->Polygon(nizTemenaMnogougla, n);
}


void Pozadina(CDC* pDC) 
{
	CPen* sivaOlovka = new CPen(PS_SOLID, 1, RGB(230, 230, 230));
	CBrush* sivaCetka = new CBrush(RGB(230, 230, 230));
	pDC->SelectObject(sivaOlovka);
	pDC->SelectObject(sivaCetka);
	pDC->Rectangle(0, 0, 500, 500);
}

void Trougao(CDC* pDC, CPoint teme1, CPoint teme2, CPoint teme3) 
{
	CPoint temena[] = { CPoint(teme1.x, teme1.y), CPoint(teme2.x, teme2.y), CPoint(teme3.x, teme3.y) };
	pDC->Polygon(temena, 3);
}

void Cetvorougao(CDC* pDC, CPoint teme1, CPoint teme2, CPoint teme3, CPoint teme4) 
{
	CPoint temena[] = { CPoint(teme1.x, teme1.y), CPoint(teme2.x, teme2.y), CPoint(teme3.x, teme3.y), CPoint(teme4.x, teme4.y) };
	pDC->Polygon(temena, 4);
}

// CLab1pripremaView drawing

void CLab1pripremaView::OnDraw(CDC* pDC)
{
	CLab1pripremaDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
#pragma region cetke/olovke
	CPen* sivaOlovka = new CPen(PS_SOLID, 1, RGB(230, 230, 230));
	CPen* zutaOlovka = new CPen(PS_SOLID, 5, RGB(255, 255, 0));
	CPen* tanjaZutaOlovka = new CPen(PS_SOLID, 3, RGB(255, 255, 0));


	CBrush* sivaCetka = new CBrush(RGB(230, 230, 230));
	CBrush* zutaCetka = new CBrush(RGB(255, 255, 0));
	CBrush* crvenaCetka = new CBrush(RGB(255, 0, 0));
	CBrush* narandzastaCetka = new CBrush(RGB(255, 140, 0));
	CBrush* rozaCetka = new CBrush(RGB(255, 192, 203));
	CBrush* zelenaCetka = new CBrush(RGB(0, 255, 0));
	CBrush* srafuraCetka = new CBrush(HS_BDIAGONAL, RGB(0, 0, 255));
	CBrush* ljubicastaCetka = new CBrush(RGB(160, 32, 240));
#pragma endregion

	CBrush* staraCetka = pDC->SelectObject(sivaCetka);
	CPen* staraOlovka = pDC->SelectObject(sivaOlovka);
	Pozadina(pDC);
	pDC->SelectObject(zutaCetka);
	pDC->SelectObject(zutaOlovka);
	pDC->Rectangle(kvadrat-2, kvadrat*3+7, kvadrat*5.5, kvadrat*8);
	pDC->SelectObject(crvenaCetka);
	Trougao(pDC, CPoint(kvadrat * 5.5, kvadrat * 3 + 7), CPoint(kvadrat * 5.5, kvadrat * 8), CPoint(kvadrat * 10, kvadrat * 3 + 7));
	pDC->SelectObject(narandzastaCetka);
	Trougao(pDC, CPoint(kvadrat * 5.5, kvadrat * 8), CPoint(kvadrat * 10, kvadrat * 3 + 7), CPoint(kvadrat * 14 + 15, kvadrat * 8));
	pDC->SelectObject(rozaCetka);
	Trougao(pDC, CPoint(kvadrat * 10, kvadrat * 8), CPoint(kvadrat * 14 + 15, kvadrat * 8), CPoint(kvadrat * 14 + 15, kvadrat * 12.7));
	pDC->SelectObject(zelenaCetka);
	Trougao(pDC, CPoint(kvadrat * 10, kvadrat * 8), CPoint(kvadrat * 10, kvadrat * 16.7), CPoint(kvadrat * 19, kvadrat * 16.7));
	pDC->SelectObject(srafuraCetka);
	Trougao(pDC, CPoint(kvadrat - 2, kvadrat * 8), CPoint(kvadrat * 10, kvadrat * 8), CPoint(kvadrat * 10, kvadrat * 16.7));
	pDC->SelectObject(ljubicastaCetka);
	Cetvorougao(pDC, CPoint(kvadrat * 14 + 15, kvadrat * 8), CPoint(kvadrat * 14 + 15, kvadrat * 12.5), CPoint(kvadrat * 19, kvadrat * 16.7), CPoint(kvadrat * 19, kvadrat * 12.5));
	pDC->SelectObject(tanjaZutaOlovka);
	pDC->SelectObject(narandzastaCetka);
	DrawRegularPolygon(pDC, kvadrat * 10, kvadrat * 6, 25, 6, 360);
	pDC->SelectObject(crvenaCetka);
	DrawRegularPolygon(pDC, kvadrat * 6.8, kvadrat * 4.7, 20, 4, 0);
	pDC->SelectObject(srafuraCetka);
	DrawRegularPolygon(pDC, kvadrat * 7.5, kvadrat * 10.5, 40, 5, 0);
	pDC->SelectObject(zelenaCetka);
	DrawRegularPolygon(pDC, kvadrat * 12.5, kvadrat * 14, 35, 7, 0);
	pDC->SelectObject(rozaCetka);
	DrawRegularPolygon(pDC, kvadrat * 13.2, kvadrat * 9.2, 20, 8, 0);
	pDC->SelectObject(staraCetka);
	pDC->SelectObject(staraOlovka);
	delete sivaOlovka;
	delete sivaCetka;
	delete zutaOlovka;
	delete zutaCetka;
	delete crvenaCetka;
	delete narandzastaCetka;
	delete rozaCetka;
	delete zelenaCetka;
	delete srafuraCetka;
	delete ljubicastaCetka;
	delete tanjaZutaOlovka;
}


// CLab1pripremaView printing

BOOL CLab1pripremaView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CLab1pripremaView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CLab1pripremaView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CLab1pripremaView diagnostics

#ifdef _DEBUG
void CLab1pripremaView::AssertValid() const
{
	CView::AssertValid();
}

void CLab1pripremaView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CLab1pripremaDoc* CLab1pripremaView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CLab1pripremaDoc)));
	return (CLab1pripremaDoc*)m_pDocument;
}
#endif //_DEBUG


// CLab1pripremaView message handlers


void CLab1pripremaView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	// TODO: Add your message handler code here and/or call default

	static bool spaceKliknut = false;
	CDC* pDC = GetDC();
	if (nChar == VK_SPACE && !spaceKliknut) {
		CPen* gridOlovka = new CPen(PS_SOLID, 2, RGB(225, 255, 255));
		pDC->SelectObject(gridOlovka);
		for (int i = 0; i < 500; i += 25)
		{
			pDC->MoveTo(0, i);
			pDC->LineTo(500, i);

			pDC->MoveTo(i, 0);
			pDC->LineTo(i, 500);

		}
		spaceKliknut = true;
		delete gridOlovka;
	}
	else if (nChar == VK_SPACE && spaceKliknut)
	{
		spaceKliknut = false;
		Invalidate();
	}


	CView::OnKeyDown(nChar, nRepCnt, nFlags);
}
