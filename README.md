# Cetvrta-godina-faks

Zadaci sa blanketa, lab vezbi itd

Drugi zadatak iz prevodioca sa blanketa je bez semanticke analize. Za dodatna objasnjenja oko FIRST I FOLLOW funkcija, u prvom zadatku, pogledaj racunsku vezbu

Grafika blanketi:

Septembar 2023 zadatak 1 - resen bez poslednje Save funkcije

Transformacije:

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

Fliker:

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
  //Funkcije za crtanje
	DrawRobot(memDC);
	pDC->BitBlt(0, 0, rect.Width(), rect.Height(), memDC, 0, 0, SRCCOPY);
	memDC->SelectObject(oldbmp);
	memDC->SetWorldTransform(&transOld);
	delete memDC;

  Klikovi na dugme:

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
	return TRUE; // ovo mora da bi fliker radio kako treba
	return CView::OnEraseBkgnd(pDC);
}

Ovo mora da bi radile transformacije:

int prevMode = SetGraphicsMode(pDC->m_hDC, GM_ADVANCED);
	XFORM xFormOld;
	pDC->GetWorldTransform(&xFormOld);
  pDC->SetWorldTransform(&xFormOld);
	pDC->SetGraphicsMode(prevMode);

  Ucitavanje aseta:
Slike:
  DImage* naziv; // ovo ide u .h
  naziv = new DImage(); // konstruktor u .cpp
  naziv->Load(CString("naziv.png")); // isto konstruktor u .cpp
delete glava; // destruktor u .cpp

Meta fajlovi:
HENHMETAFILE naziv; // .h fajl
naziv = GetEnhMetaFile(CString("naziv.emf")); // .cpp konstruktor
this->naziv = GetEnhMetaFile(CString("naziv.emf"));
DeleteEnhMetaFile(naziv); //.cpp destruktor
//f-ja
ENHMETAHEADER header;
	GetEnhMetaFileHeader(mf_viljuska, sizeof(ENHMETAHEADER), &header);
	int w = header.rclBounds.right - header.rclBounds.left;
	int h = header.rclBounds.bottom - header.rclBounds.top;
  ...
  PlayEnhMetaFile(pDC->m_hDC, mf_viljuska, CRect(0, 0, w, h));
  //Ili samo:
  pDC->PlayMetaFile(this->naziv, CRect(-15, 0, 15, -37.5));
//Olovke
  CPen* kaktusOlovka = new CPen(PS_SOLID, 1, RGB(0, 0, 0));
	// CETKE
	CBrush* pozadinskaCetka = new CBrush(RGB(135, 206, 235));
