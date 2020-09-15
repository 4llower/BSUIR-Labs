#ifndef CIRCLE_H
#define CIRCLE_H
#include <QGraphicsScene>
#include <QLineEdit>

class Circle
{
public:
    Circle();
    void makeScene(QGraphicsScene*);
    void makeEditLines(QLineEdit*, QLineEdit*, QLineEdit*);
    void makeCenter(int, int);
    void changeZoom(double);
    void view();
    bool isCenter(int, int);
    void changeParameters();
private:
    int X = 200, Y = 200;
    double Radius = 50;
    QLineEdit* center;
    QLineEdit* area;
    QLineEdit* perimetr;
    QGraphicsScene* scene;
};

#endif // CIRCLE_H
