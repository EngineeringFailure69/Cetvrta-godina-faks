
// bagerView.cpp : implementation of the CbagerView class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "bager.h"
#endif

#include "bagerDoc.h"
#include "bagerView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CbagerView

IMPLEMENT_DYNCREATE(CbagerView, CView)

BEGIN_MESSAGE_MAP(CbagerView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_ERASEBKGND()
	ON_WM_KEYDOWN()
END_MESSAGE_MAP()

// CbagerView construction/destruction

CbagerView::CbagerView() noexcept
{
	// TODO: add construction code here
	p_arm1 = new DImage();
	p_arm1->Load(CString("arm1.png"));
	p_arm2 = new DImage();
	p_arm2->Load(CString("arm2.png"));
	p_pozadina = new DImage();
	p_pozadina->Load(CString("pozadina.png"));
	p_bager = new DImage();
	p_bager->Load(CString("bager.png"));
	mf_viljuska = GetEnhMetaFile(CString("viljuska.emf"));
}

CbagerView::~CbagerView()
{
	delete p_arm1;
	delete p_arm2;
	delete p_pozadina;
	delete p_bager;
	DeleteEnhMetaFile(mf_viljuska);
}

BOOL CbagerView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CbagerView drawing

void CbagerView::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transform = { 1, 0, 0, 1, dx, dy };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CbagerView::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transform = { sx, 0, 0, sy, 0, 0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CbagerView::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transform = { cos(angle), sin(angle), -sin(angle), cos(angle), 0, 0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CbagerView::DrawBackground(CDC* pDC)
{
	CRect rect;
	GetClientRect(&rect);

	int x, y, w, h;

	x = (rect.Width() - p_pozadina->Width()) / 2;
	y = rect.Height() - p_pozadina->Height();
	w = x + p_pozadina->Width();
	h = y + p_pozadina->Height();

	p_pozadina->Draw(pDC, CRect(0, 0, p_pozadina->Width(), p_pozadina->Height()), CRect(x, y, w, h));
}

void CbagerView::DrawImgTransparent(CDC* pDC, DImage* pImage)
{
	pImage->DrawTransparent(pDC, pImage);
}

void CbagerView::DrawBody(CDC* pDC)
{
	Translate(pDC, -p_bager->Width(), -p_bager->Height(), false);
	DrawImgTransparent(pDC, p_bager);
}

void CbagerView::DrawArm1(CDC* pDC)
{
	Translate(pDC, 5, 105, false);
	Translate(pDC, 58, 61, false);
	Rotate(pDC, a1 - 90, false);
	Translate(pDC, -58, -61, false);
	DrawImgTransparent(pDC, p_arm1);
}

void CbagerView::DrawArm2(CDC* pDC)
{
	Translate(pDC, 309 - 36, 61 - 41, false);
	Translate(pDC, 36, 40, false);
	Rotate(pDC, a2 - 45, false);
	Translate(pDC, -36, -40, false);
	DrawImgTransparent(pDC, p_arm2);
}

void CbagerView::DrawFork(CDC* pDC)
{
	Translate(pDC, 272, 40, false);
	ENHMETAHEADER header;
	GetEnhMetaFileHeader(mf_viljuska, sizeof(ENHMETAHEADER), &header);
	int w = header.rclBounds.right - header.rclBounds.left;
	int h = header.rclBounds.bottom - header.rclBounds.top;
	Scale(pDC, 2.5, 2.5, false);
	Translate(pDC, -14, -20, false);
	Translate(pDC, 14, 20, false);
	Rotate(pDC, a3 - PI / 2, false);
	Translate(pDC, -14, -20, false);
	PlayEnhMetaFile(pDC->m_hDC, mf_viljuska, CRect(0, 0, w, h));
}

void CbagerView::DrawExcavator(CDC* pDC)
{
	CRect rect;
	GetClientRect(&rect);
	Translate(pDC, rect.Width(), rect.Height(), false);
	DrawBody(pDC);
	DrawArm1(pDC);
	DrawArm2(pDC);
	DrawFork(pDC);
}

void CbagerView::OnDraw(CDC* pDC)
{
	CbagerDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
	// 
	//Eliminisanje flikera
	//1
	CRect rect;
	GetClientRect(&rect);
	//2
	CDC* memDC = new CDC();
	memDC->CreateCompatibleDC(pDC);
	//3
	CBitmap bmp;
	bmp.CreateCompatibleBitmap(pDC, rect.Width(), rect.Height());
	memDC->SelectObject(&bmp);
	//4
	XFORM transold;
	int gm = memDC->SetGraphicsMode(GM_ADVANCED);
	memDC->GetWorldTransform(&transold);
	//5 - ovde su f-je za crtanje
	DrawBackground(memDC);
	Translate(memDC, -posx, 0, false);
	DrawExcavator(memDC);
	//6
	memDC->SetWorldTransform(&transold);
	memDC->SetGraphicsMode(gm);
	pDC->BitBlt(0, 0, rect.Width(), rect.Height(), memDC, 0, 0, SRCCOPY);
}


// CbagerView printing

BOOL CbagerView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CbagerView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CbagerView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CbagerView diagnostics

#ifdef _DEBUG
void CbagerView::AssertValid() const
{
	CView::AssertValid();
}

void CbagerView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CbagerDoc* CbagerView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CbagerDoc)));
	return (CbagerDoc*)m_pDocument;
}
#endif //_DEBUG


// CbagerView message handlers


BOOL CbagerView::OnEraseBkgnd(CDC* pDC)
{
	// TODO: Add your message handler code here and/or call default
	return TRUE;
	return CView::OnEraseBkgnd(pDC);
}


void CbagerView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	// TODO: Add your message handler code here and/or call default
	if (nChar == VK_LEFT) 
		posx += 10;
	else if (nChar == VK_RIGHT)
		posx -= 10;
	if (nChar == 'Q')
		a1 -= 10.0f * toRad;
	else if (nChar == 'W')
		a1 += 10.0f * toRad;
	else if (nChar == 'E')
		a2 -= 10.0f * toRad;
	else if (nChar == 'R')
		a2 += 10.0f * toRad;
	else if (nChar == 'T')
		a3 -= 10.0f * toRad;
	else if (nChar == 'Y')
		a3 += 10.0f * toRad;
	Invalidate();
	CView::OnKeyDown(nChar, nRepCnt, nFlags);
}
