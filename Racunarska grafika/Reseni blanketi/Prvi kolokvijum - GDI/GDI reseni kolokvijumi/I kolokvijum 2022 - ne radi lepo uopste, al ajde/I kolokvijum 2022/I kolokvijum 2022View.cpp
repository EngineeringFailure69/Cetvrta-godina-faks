
// I kolokvijum 2022View.cpp : implementation of the CIkolokvijum2022View class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "I kolokvijum 2022.h"
#endif

#include "I kolokvijum 2022Doc.h"
#include "I kolokvijum 2022View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CIkolokvijum2022View

IMPLEMENT_DYNCREATE(CIkolokvijum2022View, CView)

BEGIN_MESSAGE_MAP(CIkolokvijum2022View, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
	ON_WM_KEYDOWN()
END_MESSAGE_MAP()

// CIkolokvijum2022View construction/destruction

CIkolokvijum2022View::CIkolokvijum2022View() noexcept
{
	// TODO: add construction code here
	base = new DImage();
	base_shadow = new DImage();
	arm1 = new DImage();
	arm1_shadow = new DImage();
	arm2 = new DImage();
	arm2_shadow = new DImage();
	head = new DImage();
	head_shadow = new DImage();
	pozadina = new DImage();

	base->Load(CString("base.png"));
	base_shadow->Load(CString("base_shadow.png"));
	arm1->Load(CString("arm1.png"));
	arm1_shadow->Load(CString("arm1_shadow.png"));
	arm2->Load(CString("arm2.png"));
	arm2_shadow->Load(CString("arm2_shadow.png"));
	head->Load(CString("head.png"));
	head_shadow->Load(CString("head_shadow.png"));
	pozadina->Load(CString("pozadina.jpg"));
}

CIkolokvijum2022View::~CIkolokvijum2022View()
{
	delete base;
	delete base_shadow;
	delete arm1;
	delete arm1_shadow;
	delete arm2;
	delete arm2_shadow;
	delete head;
	delete head_shadow;
	delete pozadina;
}

BOOL CIkolokvijum2022View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CIkolokvijum2022View drawing

void CIkolokvijum2022View::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transform = { 1, 0, 0, 1, dx, dy };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CIkolokvijum2022View::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transform = { sx, 0, 0, sy, 0, 0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CIkolokvijum2022View::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transform = { cos(angle), sin(angle), -sin(angle), cos(angle) };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CIkolokvijum2022View::DrawBackground(CDC* pDC)
{
	CRect rect;
	GetClientRect(&rect);

	int x, y, w, h;
	x = (rect.Width() - pozadina->Width()) / 2;
	y = rect.Height() - pozadina->Height();
	w = x + pozadina->Width();
	h = y + pozadina->Height();

	pozadina->Draw(pDC, CRect(0, 0, pozadina->Width(), pozadina->Height()), CRect(x, y, w, h));
}

void CIkolokvijum2022View::DrawImgTransparent(CDC* pDC, DImage* pImage)
{
	pImage->DrawTransparent(pDC, pImage);
}

void CIkolokvijum2022View::DrawLampBase(CDC* pDC, bool bIsShadow)
{
	XFORM transform;
	pDC->GetWorldTransform(&transform);
	if (!bIsShadow) 
	{
		//Translate(pDC, base_shadow->Width(), base_shadow->Height(), false);
		//DrawImgTransparent(pDC, base);
		//Translate(pDC, -base_shadow->Width(), -base_shadow->Height(), false);
		//Translate(pDC, 309, 61, false);
		//Rotate(pDC, ugao_prva_ruka - PI / 4, false);
		//Translate(pDC, -55, 70, false);
		//DrawImgTransparent(pDC, arm1_shadow);
		Translate(pDC, -3 * base->Width(), -2 * base->Height(), false);
		DrawImgTransparent(pDC, base_shadow);
		Rotate(pDC, ugao_prva_ruka - PI / 4, false);
		Translate(pDC, 55, 70, false);
		DrawImgTransparent(pDC, arm1_shadow);
	}
	else 
	{
		Translate(pDC, -3*base->Width(), -2*base->Height(), false);
		DrawImgTransparent(pDC, base);
		Rotate(pDC, ugao_prva_ruka - PI / 4, false);
		Translate(pDC, 55, 70, false);
		DrawImgTransparent(pDC, arm1);
		//Translate(pDC, -55, -70, false);
		//Rotate(pDC, ugao_prva_ruka + PI / 4, false);
;		/*Translate(pDC, base->Width(), base->Height(), false);
		DrawImgTransparent(pDC, base);
		Translate(pDC, -base->Width(), -base->Height(), false);
		Translate(pDC, 309, 61, false);
		Rotate(pDC, ugao_prva_ruka - PI/4, false);
		Translate(pDC, -55, 70, false);
		DrawImgTransparent(pDC, arm1);*/
	}
	pDC->SetWorldTransform(&transform);
}

void CIkolokvijum2022View::DrawLampArm2(CDC* pDC, bool bIsShadow)
{
	XFORM transform;
	pDC->GetWorldTransform(&transform);
	if (bIsShadow) 
	{
		Translate(pDC, -3 * base->Width(), -2 * base->Height(), false);
		Translate(pDC, 309 - 36, 61 - 40, false);
		Rotate(pDC, ugao_druga_ruka - 3 * PI / 4, false);
		Translate(pDC, 36, 40, false);
		Translate(pDC, 5, 105, false);
		DrawImgTransparent(pDC, arm2);
	}
	else 
	{
		Translate(pDC, -3 * base->Width(), -2 * base->Height(), false);
		Translate(pDC, 309 - 36, 61 - 40, false);
		Rotate(pDC, ugao_druga_ruka - 3 * PI / 4, false);
		Translate(pDC, 36, 40, false);
		Translate(pDC, 5, 105, false);
		DrawImgTransparent(pDC, arm2_shadow);
	}
	pDC->SetWorldTransform(&transform);
}

void CIkolokvijum2022View::DrawLampHead(CDC* pDC, bool bIsShadow)
{
	XFORM transform;
	pDC->GetWorldTransform(&transform);
	if (bIsShadow) 
	{
		Translate(pDC, -3 * base->Width(), -2 * base->Height(), false);
		Translate(pDC, 272-178, 40-100, false);
		Rotate(pDC, ugao_glava + PI / 4, false);
		//Translate(pDC, -300, -600, false);
		DrawImgTransparent(pDC, head);
	}
	else 
	{
	}
	pDC->SetWorldTransform(&transform);
}

void CIkolokvijum2022View::DrawLamp(CDC* pDC, bool bIsShadow)
{
	CRect rect;
	GetClientRect(&rect);
	Translate(pDC, rect.Width(), rect.Height(), false);
	DrawLampBase(pDC, bIsShadow);
	DrawLampArm2(pDC, bIsShadow);
	DrawLampHead(pDC, bIsShadow);
}

void CIkolokvijum2022View::OnDraw(CDC* pDC)
{
	CIkolokvijum2022Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
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
	DrawLamp(memDC, true);
	//6
	memDC->SetWorldTransform(&transold);
	memDC->SetGraphicsMode(gm);
	pDC->BitBlt(0, 0, rect.Width(), rect.Height(), memDC, 0, 0, SRCCOPY);
}


// CIkolokvijum2022View printing

BOOL CIkolokvijum2022View::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CIkolokvijum2022View::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CIkolokvijum2022View::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CIkolokvijum2022View diagnostics

#ifdef _DEBUG
void CIkolokvijum2022View::AssertValid() const
{
	CView::AssertValid();
}

void CIkolokvijum2022View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CIkolokvijum2022Doc* CIkolokvijum2022View::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CIkolokvijum2022Doc)));
	return (CIkolokvijum2022Doc*)m_pDocument;
}
#endif //_DEBUG


// CIkolokvijum2022View message handlers


void CIkolokvijum2022View::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	// TODO: Add your message handler code here and/or call default
	if (nChar == '1')
		ugao_prva_ruka -= 10.0 * toRad;
	Invalidate();


	CView::OnKeyDown(nChar, nRepCnt, nFlags);
}
