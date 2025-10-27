
// Januar 2023View.cpp : implementation of the CJanuar2023View class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Januar 2023.h"
#endif

#include "Januar 2023Doc.h"
#include "Januar 2023View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define PI 3.1415

// CJanuar2023View

IMPLEMENT_DYNCREATE(CJanuar2023View, CView)

BEGIN_MESSAGE_MAP(CJanuar2023View, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CJanuar2023View construction/destruction

CJanuar2023View::CJanuar2023View() noexcept
{
	// TODO: add construction code here

}

CJanuar2023View::~CJanuar2023View()
{
}

BOOL CJanuar2023View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CJanuar2023View drawing

void CJanuar2023View::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transform = { 1, 0, 0, 1, dx, dy };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CJanuar2023View::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transform = { sx, 0, 0, sy, 0, 0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CJanuar2023View::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transform = { cos(angle), sin(angle), -sin(angle), cos(angle) };
}

void CJanuar2023View::DrawArcSpot(CDC* pDC, int size, COLORREF colFill, int widthLine, COLORREF colLine)
{
	CPen pen(PS_SOLID, widthLine, colLine);
	CBrush brush(colFill);
	CPen* oldPen = pDC->SelectObject(&pen);
	CBrush* oldBrush = pDC->SelectObject(&brush);

	// komentar: crtamo tri spojena bezier segmenta (PolyBezier)
// - levi unutrasnji:  (0,r) -> (r,0)
// - srednji iznad:    (r,0) -> (3r,0)
// - desni unutrasnji: (3r,0) -> (4r,r)

	int r = size / 4;
	const double k = 0.5522847498; // standardna konstanta

	CPoint pts[19];

	// Levi unutrasnji polukrug
	// start (0,r)
	pts[0] = CPoint(0, r);
	// kontrolne tacke koje guraju krivu *unutra* (y veca, x veca)
	pts[1] = CPoint(int(k * r), r);
	pts[2] = CPoint(r, int(k * r));
	pts[3] = CPoint(r, 0); // kraj prvog segmenta

	// Srednji luk iznad gornje stranice
	// start implicitno = pts[3] == (r,0)
	pts[4] = CPoint(int(r + k * r), int(- r - k * r));   // CP1 iznad (negativni y)
	pts[5] = CPoint(int(3 * r - k * r), int(- r - k * r)); // CP2 iznad
	pts[6] = CPoint(3 * r, 0); // kraj drugog segmenta

	// Desni unutrasnji polukrug (simetrican prvom)
	pts[7] = CPoint(3 * r, int(k * r));
	pts[8] = CPoint(int(4 * r - k * r), r);
	pts[9] = CPoint(4 * r, r); // = (size, r)

	//Srednji desni 
	pts[10] = CPoint(int(5 * r + k * r), int(r + k * r));
	pts[11] = CPoint(int(5 * r + k * r), int(3 * r - k * r));
	pts[12] = CPoint(4 * r, 3 * r);

	// Donji desni unutrasnji luk
	pts[13] = CPoint(int(4 * r - k * r), int(3 * r + k * r));
	pts[14] = CPoint(int(3 * r + k * r), int(4 * r - k * r));
	pts[15] = CPoint(int(3 * r + k * r), 4 * r);

	//Donji srednji luk
	//pts[16] = CPoint(int(3 * r - 2 * k * r), (5 * r + k * r));
	//pts[17] = CPoint(int(r + k * r), int(5 * r + k * r));
	//pts[18] = CPoint(r, 4 * r);
	// Donji srednji luk – konkavan ka spolja ispod kvadrata
// start = (3r, 4r)
	pts[16] = CPoint(int(3 * r - k * r), int(5 * r)); // cp1, ide udesno-nadole
	pts[17] = CPoint(int(r + k * r), int(5 * r)); // cp2, ide ulevo-nadole
	pts[18] = CPoint(r, 4 * r);                                // end, ulazi u levi donji ugao kvadrata

	// crtanje
	pDC->BeginPath();
	pDC->MoveTo(pts[0]);       // pocetak
	pDC->PolyBezier(pts, 19);  // crta 3 kote (svaki segment 3 kontrolne + kraj)
	pDC->EndPath();
	pDC->StrokePath();

	pDC->SelectObject(oldPen);
	pDC->SelectObject(oldBrush);
}

void CJanuar2023View::OnDraw(CDC* pDC)
{
	CJanuar2023Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
	pDC->SetGraphicsMode(GM_ADVANCED);
	XFORM transOld;
	pDC->GetWorldTransform(&transOld);
	Translate(pDC, 300, 300, false);
	DrawArcSpot(pDC, 100, RGB(0, 0, 0), 1, RGB(0, 0, 0));
	pDC->SetWorldTransform(&transOld);
}


// CJanuar2023View printing

BOOL CJanuar2023View::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CJanuar2023View::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CJanuar2023View::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CJanuar2023View diagnostics

#ifdef _DEBUG
void CJanuar2023View::AssertValid() const
{
	CView::AssertValid();
}

void CJanuar2023View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CJanuar2023Doc* CJanuar2023View::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CJanuar2023Doc)));
	return (CJanuar2023Doc*)m_pDocument;
}
#endif //_DEBUG


// CJanuar2023View message handlers
