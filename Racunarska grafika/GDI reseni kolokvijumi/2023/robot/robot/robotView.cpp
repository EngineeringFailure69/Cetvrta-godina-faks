
// robotView.cpp : implementation of the CrobotView class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "robot.h"
#endif

#include "robotDoc.h"
#include "robotView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define PI 3.14
#define toRad PI/180

// CrobotView

IMPLEMENT_DYNCREATE(CrobotView, CView)

BEGIN_MESSAGE_MAP(CrobotView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_KEYDOWN()
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

// CrobotView construction/destruction

CrobotView::CrobotView() noexcept
{
	// TODO: add construction code here
	podlakticaRot = 0;
	nadlakticaRot = 0;
	sakaRot = 0;
	roboRot = 0;
	roboScale = 1;

	glava = new DImage();
	podlaktica = new DImage();
	nadlaktica = new DImage();
	nadkolenica = new DImage();
	podkolenica = new DImage();
	saka = new DImage();
	stopalo = new DImage();
	telo = new DImage();
	pozadina = new DImage();

	glava->Load(CString("glava.png"));
	podlaktica->Load(CString("podlaktica.png"));
	nadlaktica->Load(CString("nadlaktica.png"));
	nadkolenica->Load(CString("nadkolenica.png"));
	podkolenica->Load(CString("podkolenica.png"));
	saka->Load(CString("saka.png"));
	stopalo->Load(CString("stopalo.png"));
	telo->Load(CString("telo.png"));
	pozadina->Load(CString("pozadina.jpg"));
}

CrobotView::~CrobotView()
{
	delete glava;
	delete podlaktica;
	delete nadlaktica;
	delete nadkolenica;
	delete podkolenica;
	delete saka;
	delete stopalo;
	delete telo;
	delete pozadina;
}

BOOL CrobotView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

void CrobotView::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transform = { 1, 0, 0, 1, dx, dy };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CrobotView::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transform = { sx, 0, 0, sy, 0, 0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CrobotView::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transform = { cos(angle), sin(angle), -sin(angle), cos(angle) };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CrobotView::Mirror(CDC* pDC, bool mx, bool my, bool rightMultiply)
{
	Scale(pDC, mx ? -1 : 1, my ? -1 : 1, rightMultiply);
}

void CrobotView::DrawBackground(CDC* pDC)
{
	CRect rect;
	GetClientRect(&rect);
	pozadina->Draw(pDC, CRect(0, 0, pozadina->Width(), pozadina->Height()), CRect(0, 0, rect.Width(), rect.Height()));
}

void CrobotView::DrawImgTransparent(CDC* pDC, DImage* pImage)
{
	pImage->DrawTransparent(pDC, pImage);
}

void CrobotView::DrawHalf(CDC* pDC)
{
	XFORM transform;
	pDC->GetWorldTransform(&transform);

	Translate(pDC, 25, 65, false);
	Translate(pDC, -25, -65, false);
	DrawImgTransparent(pDC, telo);

	Translate(pDC, 25 - 35, 65 - 35, false); //Pomeram se na poziciju za crtanje nadlaktice

	Translate(pDC, 35, 35, false);
	Rotate(pDC, nadlakticaRot, false);
	Translate(pDC, -35, -35, false);
	DrawImgTransparent(pDC, nadlaktica);

	Translate(pDC, 22 - 35, 167 - 35, false); //Pomeram se na poziciju za crtanje podlaktice

	Translate(pDC, 30, 33, false);
	Rotate(pDC, podlakticaRot, false);
	Translate(pDC, -30, -33, false);
	DrawImgTransparent(pDC, podlaktica);

	Translate(pDC, 30 - 30, 140 - 33, false); //Pozicija za saku

	Translate(pDC, 25, 3, false);
	Rotate(pDC, sakaRot, false);
	Translate(pDC, -25, -3, false);
	DrawImgTransparent(pDC, saka);

	pDC->SetWorldTransform(&transform);

	Translate(pDC, 61 - 29, 262 - 20, false); //Pozicija za nadkolenicu
	DrawImgTransparent(pDC, nadkolenica);

	Translate(pDC, 30 - 25, 184 - 37, false); //Pozicija za podkolenicu
	DrawImgTransparent(pDC, podkolenica);

	Translate(pDC, 25 - 20, 248 - 16, false);
	DrawImgTransparent(pDC, stopalo);

	pDC->SetWorldTransform(&transform);
}

void CrobotView::DrawHead(CDC* pDC)
{
	DrawImgTransparent(pDC, glava);
}

void CrobotView::DrawRobot(CDC* pDC)
{
	CRect rect;
	GetClientRect(&rect);
	DrawBackground(pDC);
	Translate(pDC, rect.Width() / 2 - telo->Width(), rect.Height() / 2 - telo->Height(), false);
	DrawHalf(pDC);
	Mirror(pDC, true, false, false);
	Translate(pDC, -2 * telo->Width(), 0, false);
	DrawHalf(pDC);
	Translate(pDC, -rect.Width() / 2 + telo->Width(), -rect.Height() / 2 + telo->Height(), false);
	Translate(pDC, rect.Width() / 2 - glava->Width() / 2, rect.top + glava->Width() / 2, false);
	DrawHead(pDC);
	Translate(pDC, -(rect.Width() / 2 - glava->Width() / 2), -(rect.top + glava->Width() / 2), false);
}

// CrobotView drawing

void CrobotView::OnDraw(CDC* pDC)
{
	CrobotDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
	//Eliminisanje flikera
	CRect rect;
	GetClientRect(&rect);
	CDC* memDC = new CDC();
	memDC->CreateCompatibleDC(pDC);
	CBitmap bmp;
	bmp.CreateCompatibleBitmap(pDC, rect.Width(), rect.Height());
	CBitmap* oldbmp = memDC->SelectObject(&bmp);
	memDC->SetGraphicsMode(GM_ADVANCED);
	XFORM transOld;
	memDC->GetWorldTransform(&transOld);
	DrawRobot(memDC);
	pDC->BitBlt(0, 0, rect.Width(), rect.Height(), memDC, 0, 0, SRCCOPY);
	memDC->SelectObject(oldbmp);
	memDC->SetWorldTransform(&transOld);
	delete memDC;
}


// CrobotView printing

BOOL CrobotView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CrobotView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CrobotView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CrobotView diagnostics

#ifdef _DEBUG
void CrobotView::AssertValid() const
{
	CView::AssertValid();
}

void CrobotView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CrobotDoc* CrobotView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CrobotDoc)));
	return (CrobotDoc*)m_pDocument;
}
#endif //_DEBUG


// CrobotView message handlers


void CrobotView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	// TODO: Add your message handler code here and/or call default
	if (nChar == 'A') 
	{
		if (sakaRot > -10 * toRad)
			sakaRot -= 5 * toRad;
	}
	else if (nChar == 'S') 
	{
		if (sakaRot < 30 * toRad)
			sakaRot += 5 * toRad;
	}
	else if (nChar == 'D') 
	{
		if (podlakticaRot > -10 * toRad)
			podlakticaRot -= 5 * toRad;
	}
	else if (nChar == 'F') 
	{
		if (podlakticaRot < 80 * toRad)
			podlakticaRot += 5 * toRad;
	}
	else if (nChar == 'G') 
	{
		if (nadlakticaRot > -10 * toRad)
			nadlakticaRot -= 5 * toRad;
	}
	else if (nChar == 'H') 
	{
		if (nadlakticaRot < 90 * toRad)
			nadlakticaRot += 5 * toRad;
	}
	Invalidate();
	CView::OnKeyDown(nChar, nRepCnt, nFlags);
}


BOOL CrobotView::OnEraseBkgnd(CDC* pDC)
{
	// TODO: Add your message handler code here and/or call default
	return TRUE;
	return CView::OnEraseBkgnd(pDC);
}