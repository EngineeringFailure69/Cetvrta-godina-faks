
// Lab2-pripremaView.h : interface of the CLab2pripremaView class
//

#pragma once


class CLab2pripremaView : public CView
{
protected: // create from serialization only
	CLab2pripremaView() noexcept;
	DECLARE_DYNCREATE(CLab2pripremaView)

// Attributes
public:
	CLab2pripremaDoc* GetDocument() const;

	HENHMETAFILE svetliDeo;
	HENHMETAFILE tamniDeo;

	float prviUgao;
	float drugiUgao;

// Operations
public:

// Overrides
public:
	void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	void Scale(CDC* pDC, /*HENHMETAFILE fajl*/ float sx, float sy, bool rightMultiply);
	void Rotate(CDC* pDC, float angle, bool rightMultiply);
	void Saksija(CDC* pDC);
	void Kaktus(CDC* pDC);

	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CLab2pripremaView();
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

#ifndef _DEBUG  // debug version in Lab2-pripremaView.cpp
inline CLab2pripremaDoc* CLab2pripremaView::GetDocument() const
   { return reinterpret_cast<CLab2pripremaDoc*>(m_pDocument); }
#endif

