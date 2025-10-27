
// Januar 2023View.h : interface of the CJanuar2023View class
//

#pragma once


class CJanuar2023View : public CView
{
protected: // create from serialization only
	CJanuar2023View() noexcept;
	DECLARE_DYNCREATE(CJanuar2023View)

// Attributes
public:
	CJanuar2023Doc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	virtual void Scale(CDC* pDC, float sx, float sy, bool rightMultiply);
	virtual void Rotate(CDC* pDC, float angle, bool rightMultiply);
	virtual void DrawArcSpot(CDC* pDC, int size, COLORREF colFill, int widthLine, COLORREF colLine);

	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CJanuar2023View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in Januar 2023View.cpp
inline CJanuar2023Doc* CJanuar2023View::GetDocument() const
   { return reinterpret_cast<CJanuar2023Doc*>(m_pDocument); }
#endif

