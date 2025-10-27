
// Januar 2024View.h : interface of the CJanuar2024View class
//

#pragma once


class CJanuar2024View : public CView
{
protected: // create from serialization only
	CJanuar2024View() noexcept;
	DECLARE_DYNCREATE(CJanuar2024View)

// Attributes
public:
	CJanuar2024Doc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	virtual void Scale(CDC* pDC, float sx, float sy, bool rightMultiply);
	virtual void Rotate(CDC* pDC, float angle, bool rightMultiply);
	virtual void DrawPetal(CDC* pDC, CRect rect, COLORREF clrFill, COLORREF clrLine);
	virtual void DrawSnowFlake(CDC* pDC, CRect rect, COLORREF clrFill, COLORREF clrLine, int nArcs, float dRot, CString str);
	virtual void DrawSnowFlakes(CDC* pDC, CRect* aRect, COLORREF* aClrFill, COLORREF* sClrLine, int* anArcs, float* aRot, CString* aStr, CPoint* aPts);

	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CJanuar2024View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in Januar 2024View.cpp
inline CJanuar2024Doc* CJanuar2024View::GetDocument() const
   { return reinterpret_cast<CJanuar2024Doc*>(m_pDocument); }
#endif

