#ifndef OTWORZ_H
#define OTWORZ_H

#include <QDialog>

namespace Ui {
class otworz;
}

class otworz : public QDialog
{
    Q_OBJECT

public:
    explicit otworz(QWidget *parent = nullptr);
    ~otworz();

private:
    Ui::otworz *ui;
};

#endif // OTWORZ_H
