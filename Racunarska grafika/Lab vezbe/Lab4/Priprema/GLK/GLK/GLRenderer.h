#pragma once
#pragma comment(lib, "OpenGL32.lib")
#pragma comment(lib, "glu32.lib")

#include <GL\gl.h>
#include <GL\glu.h>

#define _USE_MATH_DEFINES
#include <math.h>

#define DEO_KAKTUSA 0.0, 1.0, 0.0
#define DEO_ZA_ROTIRANJE 1.0, 1.0, 0.0
#define SFERA 0.00, 0.8, 0.0


class CGLRenderer
{
public:
	CGLRenderer(void);
	virtual ~CGLRenderer(void);
		
	bool CreateGLContext(CDC* pDC);			// kreira OpenGL Rendering Context
	void PrepareScene(CDC* pDC);			// inicijalizuje scenu,
	void Reshape(CDC* pDC, int w, int h);	// kod koji treba da se izvrsi svaki put kada se promeni velicina prozora ili pogleda i
	void DrawScene(CDC* pDC);				// iscrtava scenu
	void DestroyScene(CDC* pDC);			// dealocira resurse alocirane u drugim funkcijama ove klase,

	// DODATNE F-JE
	void DrawSphere(double r, int nSegAlpha, int nSegBeta);
	void DrawCylinder(double h, double r1, double r2, int nSeg);
	void DrawCone(double h, double r, int nSeg);
	void DrawAxis(double width);
	void DrawGrid(double width, double height, int nSegW, int nSegH);
	void DrawFigure(double angle);

	// F-JE ZA IZRACUNAVANJE POZICIJE I ROTACIJU

	void RotateView(double dXY, double dXZ);
	void CalculatePosition();

protected:
	HGLRC	 m_hrc; //OpenGL Rendering Context 

public:

	float angle = 0;

	double viewAngleXY;
	double viewAngleXZ;
	double viewR;

	double eyex, eyey, eyez;
	double centerx, centery, centerz;
	double upx, upy, upz;
};
