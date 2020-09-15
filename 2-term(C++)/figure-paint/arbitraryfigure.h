#ifndef ARBITRARYFIGURE_H
#define ARBITRARYFIGURE_H
#include <QGraphicsScene>
#include <QLineEdit>
#include <QPair>
#include <QDebug>
#include <algorithm>
#include <cmath>

class ArbitraryFigure
{
public:
    ArbitraryFigure();
    void makeStandart(QGraphicsScene*, QLineEdit*, QLineEdit*, QLineEdit*);
    void addPoint(int, int);
    void changeZoom(double);
    void view();
    void calcCenter();
    bool isCenter(int, int);
    void clearVector();
    void changePoints(int, int);
    void changeParameters();
    double getPerimetr();
    double getArea();
    double getDistance(int, int, int, int);
    void rotateToPoint(double);
    bool isAnyPoints(int, int);
    void changePointCorner(int, int);
private:
    QGraphicsScene* scene;
    QVector <QPair <double, double> > Points;
    int Zoom = 1;
    QLineEdit* area;
    QLineEdit* center;
    QLineEdit* perimetr;
    int cX, cY;
};

#endif // ARBITRARYFIGURE_H
