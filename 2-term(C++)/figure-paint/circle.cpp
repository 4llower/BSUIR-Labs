#include "circle.h"
#include <QDebug>

Circle::Circle()
{

}

void Circle::makeCenter(int X, int Y) {
    this -> X = X;
    this -> Y = Y;
    changeParameters();
}

void Circle::makeEditLines(QLineEdit* center, QLineEdit* area, QLineEdit* perimetr){
    this -> center = center;
    this -> area = area;
    this -> perimetr = perimetr;
}

void Circle::makeScene(QGraphicsScene* scene){
    this -> scene = scene;
}

bool Circle::isCenter(int x, int y){
    return (abs(x - X) <= 10 && abs(Y - y) <= 10);
}

void Circle::view(){
    scene -> clear();
    scene -> addEllipse(X - Radius / 2, Y - Radius / 2, Radius, Radius, QPen(Qt::black));
    scene -> addEllipse(X - 5, Y - 5, 10, 10);
    changeParameters();
}

void Circle::changeParameters(){
    center -> setText(QString::number(X) + "," + QString::number(Y));
    perimetr -> setText(QString::number(2 * M_PI * Radius));
    area -> setText(QString::number(M_PI * Radius * Radius));
}

void Circle::changeZoom(double Zoom){
    if (Zoom == 0) return;
    Radius *= Zoom;
}

