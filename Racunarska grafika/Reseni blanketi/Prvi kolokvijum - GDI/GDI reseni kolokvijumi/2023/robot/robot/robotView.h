
// robotView.h : interface of the CrobotView class
//

#pragma once
#include "DImage.h"

class CrobotView : public CView
{
protected: // create from serialization only
	CrobotView() noexcept;
	DECLARE_DYNCREATE(CrobotView)

// Attributes
public:
	CrobotDoc* GetDocument() const;

	float podlakticaRot;
	float nadlakticaRot;
	float sakaRot;
	float roboRot;
	float roboScale;

	DImage* glava;
	DImage* podlaktica;
	DImage* nadlaktica;
	DImage* nadkolenica;
	DImage* podkolenica;
	DImage* saka;
	DImage* stopalo;
	DImage* telo;
	DImage* pozadina;
// Operations
public:

// Overrides
public:
	virtual void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	virtual void Scale(CDC* pDC, float sx, float sy, bool rightMultiply);
	virtual void Rotate(CDC* pDC, float angle, bool rightMultiply);
	virtual void Mirror(CDC* pDC, bool mx, bool my, bool rightMultiply);
	virtual void DrawBackground(CDC* pDC);
	virtual void DrawImgTransparent(CDC* pDC, DImage* pImage);
	virtual void DrawHalf(CDC* pDC);
	virtual void DrawHead(CDC* pDC);
	virtual void DrawRobot(CDC* pDC);


	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CrobotView();
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
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
};

#ifndef _DEBUG  // debug version in robotView.cpp
inline CrobotDoc* CrobotView::GetDocument() const
   { return reinterpret_cast<CrobotDoc*>(m_pDocument); }
#endif

