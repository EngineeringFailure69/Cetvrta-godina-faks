
// I kolokvijum 2022View.h : interface of the CIkolokvijum2022View class
//

#pragma once
#include "DImage.h"

class CIkolokvijum2022View : public CView
{
protected: // create from serialization only
	CIkolokvijum2022View() noexcept;
	DECLARE_DYNCREATE(CIkolokvijum2022View)

// Attributes
public:
	CIkolokvijum2022Doc* GetDocument() const;

	DImage* base;
	DImage* arm1;
	DImage* arm2;
	DImage* head;
	DImage* pozadina;
	DImage* base_shadow;
	DImage* arm1_shadow;
	DImage* arm2_shadow;
	DImage* head_shadow;

	double ugao_prva_ruka = 0, ugao_druga_ruka = 0, ugao_glava = 0;
	#define PI 3.14
	#define toRad PI / 180
// Operations
public:

// Overrides
public:
	virtual void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	virtual void Scale(CDC* pDC, float sx, float sy, bool rightMultiply);
	virtual void Rotate(CDC* pDC, float angle, bool rightMultiply);
	virtual void DrawBackground(CDC* pDC);
	virtual void DrawImgTransparent(CDC* pDC, DImage* pImage);
	virtual void DrawLampBase(CDC* pDC, bool bIsShadow);
	virtual void DrawLampArm2(CDC* pDC, bool bIsShadow);
	virtual void DrawLampHead(CDC* pDC, bool bIsShadow);
	virtual void DrawLamp(CDC* pDC, bool bIsShadow);

	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CIkolokvijum2022View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
};

#ifndef _DEBUG  // debug version in I kolokvijum 2022View.cpp
inline CIkolokvijum2022Doc* CIkolokvijum2022View::GetDocument() const
   { return reinterpret_cast<CIkolokvijum2022Doc*>(m_pDocument); }
#endif

