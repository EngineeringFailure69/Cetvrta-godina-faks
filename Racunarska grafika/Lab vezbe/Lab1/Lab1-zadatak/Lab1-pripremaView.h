
// Lab1-pripremaView.h : interface of the CLab1pripremaView class
//

#pragma once


class CLab1pripremaView : public CView
{
protected: // create from serialization only
	CLab1pripremaView() noexcept;
	DECLARE_DYNCREATE(CLab1pripremaView)

// Attributes
public:
	CLab1pripremaDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual void DrawRegularPolygon(CDC* pDC, int cx, int cy, int r, int n, float rotAngle);
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CLab1pripremaView();
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

#ifndef _DEBUG  // debug version in Lab1-pripremaView.cpp
inline CLab1pripremaDoc* CLab1pripremaView::GetDocument() const
   { return reinterpret_cast<CLab1pripremaDoc*>(m_pDocument); }
#endif

