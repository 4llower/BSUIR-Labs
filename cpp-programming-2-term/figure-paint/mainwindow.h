#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "arbitraryfigure.h"
#include <circle.h>
#include <QMouseEvent>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void on_paintButton_clicked();

    void on_ZoomPushButton_clicked();

    void on_AnglePushButton_clicked();

    void on_changeCenter_clicked();

    void on_ClearButton_clicked();

private:
    Ui::MainWindow *ui;
    ArbitraryFigure* figure;
    Circle* circle;
    int holded = 0;
    int isDrawn = 1;
    double currentZoom;
    double allZoom = 1;
    bool eventFilter(QObject *watched, QEvent *event) override;

};
#endif // MAINWINDOW_H
