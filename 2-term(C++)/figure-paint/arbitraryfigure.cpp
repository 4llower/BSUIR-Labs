#include "arbitraryfigure.h"

ArbitraryFigure::ArbitraryFigure() {

}

void ArbitraryFigure::makeStandart(QGraphicsScene* scene, QLineEdit* center, QLineEdit* area, QLineEdit* perimetr) {
    this -> scene = scene;
    this -> center = center;
    this -> area = area;
    this -> perimetr = perimetr;
}

void ArbitraryFigure::addPoint(int x, int y){
    scene -> addEllipse(x - 5, y - 5, 10, 10);
    Points.push_back(qMakePair(x, y));
}

void ArbitraryFigure::view(){
    scene -> clear();
    QPolygon poly;

    for (int i = 0; i < Points.size(); ++i){
        poly << QPoint(Points[i].first, Points[i].second);
    }

    calcCenter();
    changeParameters();

    scene -> addEllipse(cX - 5, cY - 5, 10, 10);
    scene -> addPolygon(poly);
    scene -> update();
}

void ArbitraryFigure::calcCenter(){
    cX = 0, cY = 0;
    for (int i = 0; i < Points.size(); ++i) cX += Points[i].first, cY += Points[i].second;
    cX /= Points.size();
    cY /= Points.size();
}

bool ArbitraryFigure::isCenter(int x, int y){
    return (abs(x - cX) <= 10 && abs(y - cY) <= 10);
}

void ArbitraryFigure::clearVector(){
    Points.clear();
}

void ArbitraryFigure::changePoints(int x, int y){
    for (int i = 0; i < Points.size(); ++i){
        Points[i].first += (x - cX);
        Points[i].second += (y - cY);
    }
    cX = x;
    cY = y;
}

void ArbitraryFigure::changeParameters(){
    center -> setText(QString::number(cX) + "," + QString::number(cY));
    perimetr -> setText(QString::number(getPerimetr()));
    area -> setText(QString::number(getArea()));
}

double ArbitraryFigure::getArea(){
    double ans = 0;
    for (int i = 0; i < Points.size(); ++i){
        QPair <int, int> now, to;
        if (i == 0) now = Points.back(); else now = Points[i - 1];
        to = Points[i];
        ans += (now.first - to.first) * (now.second + to.second);
    }
    return fabs(ans) / 2;
}

double ArbitraryFigure::getPerimetr(){
    double ans = 0;
    for (int i = 1; i < Points.size(); ++i){
        ans += getDistance(Points[i].first, Points[i].second, Points[i - 1].first, Points[i - 1].second);
    }
    return ans;
}

double ArbitraryFigure::getDistance(int x, int y, int X, int Y){
    return sqrt((x - X) * (x - X) + (y - Y) * (y - Y));
}

void ArbitraryFigure::changeZoom(double Zoom){
    for (int i = 0; i < Points.size(); ++i){
        Points[i].first += (((Points[i].first - cX + 0.5) * Zoom) - (Points[i].first - cX));
        Points[i].second += (((Points[i].second - cY + 0.5) * Zoom) - (Points[i].second - cY));
    }
    calcCenter();
}

void ArbitraryFigure::rotateToPoint(double angle){
    angle = angle / 180.0 * M_PI;
    for(int i = 0; i < Points.size(); i++)
    {
        double x = Points[i].first, y = Points[i].second;
        Points[i].first = (x - cX) * cos(angle) - (y - cY) * sin(angle) + cX;
        Points[i].second = (x - cX) * sin(angle) + (y - cY) * cos(angle) + cY;
    }
}

bool ArbitraryFigure::isAnyPoints(int x, int y){
    for (int i = 0; i < Points.size(); ++i) if (getDistance(x, y, Points[i].first, Points[i].second) < 10.0) return 1;
    return 0;
}

void ArbitraryFigure::changePointCorner(int x, int y){
    double mn = 1e9;
    int pos = 0;
    for (int i = 0; i < Points.size(); ++i) {
        if (mn > getDistance(x, y, Points[i].first, Points[i].second)){
            mn = getDistance(x, y, Points[i].first, Points[i].second);
            pos = i;
        }
    }
    Points[pos].first = x;
    Points[pos].second = y;
}
