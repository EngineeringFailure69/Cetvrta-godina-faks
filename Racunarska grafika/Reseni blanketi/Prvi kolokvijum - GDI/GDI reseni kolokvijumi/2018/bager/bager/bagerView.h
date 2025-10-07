
// bagerView.h : interface of the CbagerView class
//

#pragma once
#include "DImage.h"

#define PI 3.14
#define toRad PI / 180
#define toDeg 180 / PI

class CbagerView : public CView
{
protected: // create from serialization only
	CbagerView() noexcept;
	DECLARE_DYNCREATE(CbagerView)

// Attributes
public:
	CbagerDoc* GetDocument() const;

	DImage* p_arm1;
	DImage* p_arm2;
	DImage* p_bager;
	DImage* p_pozadina;
	HENHMETAFILE mf_viljuska;

// Operations
public:

// Overrides
public:
	float a1 = 0.0f, a2 = 0.0f, a3 = 0.0f;
	int posx = 10;

	virtual void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	virtual void Scale(CDC* pDC, float sx, float sy, bool rightMultiply);
	virtual void Rotate(CDC* pDC, float angle, bool rightMultiply);
	virtual void DrawBackground(CDC* pDC);
	virtual void DrawImgTransparent(CDC* pDC, DImage* pImage);
	virtual void DrawBody(CDC* pDC);
	virtual void DrawArm1(CDC* pDC);
	virtual void DrawArm2(CDC* pDC);
	virtual void DrawFork(CDC* pDC);
	virtual void DrawExcavator(CDC* pDC);

	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CbagerView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
};

#ifndef _DEBUG  // debug version in bagerView.cpp
inline CbagerDoc* CbagerView::GetDocument() const
   { return reinterpret_cast<CbagerDoc*>(m_pDocument); }
#endif

