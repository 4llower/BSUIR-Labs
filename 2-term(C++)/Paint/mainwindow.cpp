#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QGraphicsScene>
#include <QDebug>
#include <QEvent>
#include <QPoint>
#include <QTimer>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    qApp->installEventFilter(this);
    QGraphicsScene *Scene = new QGraphicsScene(this);

    Scene->setSceneRect(0,0,700,500);
    Scene->setItemIndexMethod(QGraphicsScene::NoIndex);

    ui->graphicsView->setFrameStyle(0);
    ui->graphicsView->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->graphicsView->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    ui->graphicsView->setRenderHint(QPainter::Antialiasing);
    ui->graphicsView->setCacheMode(QGraphicsView::CacheNone);
    ui->graphicsView->setScene(Scene);
    ui->graphicsView->scene()->update();

    figure = new ArbitraryFigure();
    figure -> makeStandart(Scene, ui->CentreOutput, ui->ArreaOutput, ui->PerimetrOutput);

    circle = new Circle();
    circle -> makeScene(Scene);
    circle -> makeEditLines(ui->CentreOutput, ui->ArreaOutput, ui->PerimetrOutput);

}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_paintButton_clicked()
{
    if (ui->comboBox->currentText() == "Circle") circle -> view();
    else {
        if (isDrawn == 1){
            isDrawn = 0;
        } else {
            isDrawn = 1;
            figure -> view();
        }
    }
}

void MainWindow::on_ZoomPushButton_clicked()
{
    double finish = ui->ZoomInput->text().toDouble();

    if (finish < 1) currentZoom = 0.9;
    else currentZoom = 1.05;

    if (fabs(finish - allZoom) < 1e-2 || (allZoom > finish && finish > 1) || (allZoom < finish && finish < 1)) {
        allZoom = 1;
        ui->ZoomInput->setText("");
        return;
    }

    allZoom *= currentZoom;

    if (ui->comboBox->currentText() == "Circle"){
        QTimer::singleShot(10, this, SLOT(on_ZoomPushButton_clicked()));
        circle->changeZoom(currentZoom);
        circle->view();
    } else {
        QTimer::singleShot(10, this, SLOT(on_ZoomPushButton_clicked()));
        figure->changeZoom(currentZoom);
        figure->view();
    }
}

void MainWindow::on_AnglePushButton_clicked()
{
    if (ui->comboBox->currentText() != "Circle"){
        double finish = ui->AngleInput->text().toDouble();

        if (fabs(finish) < 1) {
            ui->AngleInput->setText("");
            return;
        }

        QTimer::singleShot(10, this, SLOT(on_AnglePushButton_clicked()));

        figure -> rotateToPoint(1.0);
        figure -> view();
        finish -= 1.0;

        ui->AngleInput->setText(QString::number(finish));
    }
}

void MainWindow::on_changeCenter_clicked()
{
    if (ui->comboBox->currentText() == "Circle"){
        QString s = ui->CentreOutput->text();

        int x = s.mid(0, s.indexOf(",")).toInt();
        int y = s.mid(s.indexOf(",") + 1, s.size()).toInt();

        circle -> makeCenter(x, y);
        circle -> view();
    }
}

bool MainWindow::eventFilter(QObject *watched, QEvent *event)
{
    if (ui->comboBox->currentText() == "Circle"){

        if (event->type() == QEvent::MouseButtonPress){

            QMouseEvent *MouseEvent = static_cast<QMouseEvent *>(event);

            if(MouseEvent->buttons() == Qt::LeftButton){
                if (holded) {
                    holded = 0;
                } else {

                    int x = MouseEvent->x();
                    int y = MouseEvent->y();

                    if (circle -> isCenter(x, y)){
                        holded = 1;
                    }
                }
            }
        }

        if(event->type() == QEvent::MouseMove && holded) {

            QMouseEvent *MouseEvent = static_cast<QMouseEvent *>(event);

            int x = MouseEvent->x();
            int y = MouseEvent->y();

            circle -> makeCenter(x, y);
            circle -> view();
        }
    }else {
        if (!isDrawn){

            if (event->type() == QEvent::MouseButtonPress){

                QMouseEvent *MouseEvent = static_cast<QMouseEvent *>(event);

                if(MouseEvent->buttons() == Qt::LeftButton){
                    int x = MouseEvent->x();
                    int y = MouseEvent->y();
                    if (!(x <= 700 && y <= 500 && x >= 0 && y >= 0)) {
                        on_paintButton_clicked();
                    } else figure -> addPoint(x, y);
                }

            }
        }
        else {
            if (event->type() == QEvent::MouseButtonPress){

                QMouseEvent *MouseEvent = static_cast<QMouseEvent *>(event);

                if(MouseEvent->buttons() == Qt::LeftButton){
                    if (holded){
                        holded = 0;
                    } else {
                        int x = MouseEvent->x();
                        int y = MouseEvent->y();
                        if (figure -> isCenter(x, y) || figure -> isAnyPoints(x, y)) {
                            holded = 1;
                        }
                    }
                }
            }
            if(event->type() == QEvent::MouseMove && holded) {

                QMouseEvent *MouseEvent = static_cast<QMouseEvent *>(event);

                double x = MouseEvent->x();
                double y = MouseEvent->y();

                if (figure -> isAnyPoints(x, y)) figure -> changePointCorner(x, y);
                else figure -> changePoints(x, y);
                figure -> view();
            }
        }
    }
}

void MainWindow::on_ClearButton_clicked()
{
    ui->graphicsView->scene()->clear();
    figure -> clearVector();
}
