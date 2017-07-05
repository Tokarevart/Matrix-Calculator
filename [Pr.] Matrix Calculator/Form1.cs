using System;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace _Pr.__Matrix_Calculator
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add(Name, Text);
            dataGridView1.Columns.Add(Name, Text);
            dataGridView1.Columns.Add(Name, Text);
            dataGridView1.Rows.Add(3);
            dataGridView2.Columns.Add(Name, Text);
            dataGridView2.Columns.Add(Name, Text);
            dataGridView2.Columns.Add(Name, Text);
            dataGridView2.Rows.Add(3);
        }

        private void ChangeDimsBtn1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ChangeCAndR(dataGridView1.ColumnCount, dataGridView1.RowCount);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.ColumnCount = f2.cols;
                dataGridView1.RowCount = f2.rows;
            }
        }

        private void ChangeDimsBtn2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ChangeCAndR(dataGridView2.ColumnCount, dataGridView2.RowCount);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                dataGridView2.ColumnCount = f2.cols;
                dataGridView2.RowCount = f2.rows;
            }
        }

        private void ClearBtn1_Click(object sender, EventArgs e)
        {
            int bufrowc = dataGridView1.RowCount;
            dataGridView1.RowCount = 0;
            int bufcolc = dataGridView1.ColumnCount;
            dataGridView1.ColumnCount = 0;
            dataGridView1.ColumnCount = bufcolc;
            dataGridView1.RowCount = bufrowc;
        }

        private void ClearBtn2_Click(object sender, EventArgs e)
        {
            int bufrowc = dataGridView2.RowCount;
            dataGridView2.RowCount = 0;
            int bufcolc = dataGridView2.ColumnCount;
            dataGridView2.ColumnCount = 0;
            dataGridView2.ColumnCount = bufcolc;
            dataGridView2.RowCount = bufrowc;
        }

        private void ExchangeBtn_Click(object sender, EventArgs e)
        {
            object[,] Matr = new object[dataGridView1.RowCount, dataGridView1.ColumnCount];
            int MatrColN = dataGridView1.ColumnCount, MatrRowN = dataGridView1.RowCount;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = dataGridView1[j, i].Value;
            }
            dataGridView1.ColumnCount = dataGridView2.ColumnCount;
            dataGridView1.RowCount = dataGridView2.RowCount;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++) dataGridView1[j, i].Value = dataGridView2[j, i].Value;
            }
            dataGridView2.ColumnCount = MatrColN;
            dataGridView2.RowCount = MatrRowN;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++) dataGridView2[j, i].Value = Matr[i, j];
            }
        }

        private void TransBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
                Matr = Matr.Transpose();
                int temp = dataGridView1.RowCount;
                dataGridView1.RowCount = dataGridView1.ColumnCount;
                dataGridView1.ColumnCount = temp;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) dataGridView1[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void TransBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount);
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                }
                Matr = Matr.Transpose();
                int temp = dataGridView2.RowCount;
                dataGridView2.RowCount = dataGridView2.ColumnCount;
                dataGridView2.ColumnCount = temp;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++) dataGridView2[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void SumMatrBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount == dataGridView2.ColumnCount && dataGridView1.RowCount == dataGridView2.RowCount)
            {
                try
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            Convert.ToDouble(dataGridView1[i, j].Value);
                            Convert.ToDouble(dataGridView2[i, j].Value);
                        }
                    }
                    dataGridView3.RowCount = 0;
                    dataGridView3.ColumnCount = 0;
                    dataGridView3.ColumnCount = dataGridView1.RowCount;
                    dataGridView3.RowCount = dataGridView1.ColumnCount;
                    for (int i = 0; i < dataGridView3.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView3.RowCount; j++) dataGridView3[i, j].Value = Convert.ToDouble(dataGridView1[i, j].Value) + Convert.ToDouble(dataGridView2[i, j].Value);
                    }
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
            }
            else MessageBox.Show("Ошибка!\nМатрицы должны быть одной размерности.");
        }

        private void DiffMatrBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount == dataGridView2.ColumnCount && dataGridView1.RowCount == dataGridView2.RowCount)
            {
                try
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            Convert.ToDouble(dataGridView1[i, j].Value);
                            Convert.ToDouble(dataGridView2[i, j].Value);
                        }
                    }
                    dataGridView3.RowCount = 0;
                    dataGridView3.ColumnCount = 0;
                    dataGridView3.ColumnCount = dataGridView1.RowCount;
                    dataGridView3.RowCount = dataGridView1.ColumnCount;
                    for (int i = 0; i < dataGridView3.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView3.RowCount; j++) dataGridView3[i, j].Value = Convert.ToDouble(dataGridView1[i, j].Value) - Convert.ToDouble(dataGridView2[i, j].Value);
                    }
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
            }
            else MessageBox.Show("Ошибка!\nМатрицы должны быть одной размерности.");
        }

        private void MultMatrBtn_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount; j++) Convert.ToDouble(dataGridView1[i, j].Value);
                }
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView2.RowCount; j++) Convert.ToDouble(dataGridView2[i, j].Value);
                }
                if (dataGridView1.ColumnCount == dataGridView2.RowCount)
                {
                    dataGridView3.RowCount = 0;
                    dataGridView3.ColumnCount = 0;
                    dataGridView3.ColumnCount = dataGridView2.ColumnCount;
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    for (int i = 0; i < dataGridView3.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView3.RowCount; j++) dataGridView3[i, j].Value = "0";
                    }
                    for (int k = 0; k < dataGridView1.RowCount; k++)
                    {
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            for (int i = 0; i < dataGridView2.RowCount; i++) dataGridView3[j, k].Value = Convert.ToDouble(dataGridView3[j, k].Value) + (Convert.ToDouble(dataGridView1[i, k].Value) * Convert.ToDouble(dataGridView2[j, i].Value));
                        }
                    }
                }
                else MessageBox.Show("Ошибка!\nКол-во столбцов 1-ой матрицы должно быть равно кол-ву строк 2-ой матрицы.");
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void CopyInA_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 0;
            dataGridView1.ColumnCount = 0;
            dataGridView1.ColumnCount = dataGridView3.ColumnCount;
            dataGridView1.RowCount = dataGridView3.RowCount;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++) dataGridView1[i, j].Value = dataGridView3[i, j].Value;
            }
        }

        private void CopyInB_Click(object sender, EventArgs e)
        {
            dataGridView2.RowCount = 0;
            dataGridView2.ColumnCount = 0;
            dataGridView2.ColumnCount = dataGridView3.ColumnCount;
            dataGridView2.RowCount = dataGridView3.RowCount;
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView2.RowCount; j++) dataGridView2[i, j].Value = dataGridView3[i, j].Value;
            }
        }

        private void MultBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
                Matr = Matr.Multiply(Convert.ToInt32(MultNum1.Text));
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++) dataGridView1[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы и множитель должны быть числами."); }
        }

        private void MultBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount);
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                }
                Matr = Matr.Multiply(Convert.ToInt32(MultNum2.Text));
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    for (int i = 0; i < dataGridView2.RowCount; i++) dataGridView2[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы и множитель должны быть числами."); }
        }

        private void DetermBtn1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == dataGridView1.ColumnCount)
            {
                try
                {
                    var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                    ResultNum1.Text = Convert.ToString(Matr.Determinant());
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
            }
            else MessageBox.Show("Ошибка!\nМатрица должна быть квадратной.");
        }

        private void DetermBtn2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == dataGridView2.ColumnCount)
            {
                try
                {
                    var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount);
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView2.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                    }
                    ResultNum2.Text = Convert.ToString(Matr.Determinant());
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
            }
            else MessageBox.Show("Ошибка!\nМатрица должна быть квадратной.");
        }

        private void RangBtn1_Click(object sender, EventArgs e)
        {
            /*var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
            }
            ResultNum.Text = Convert.ToString(Matr.Rank());*/
        }

        private void RaiseBtn1_Click(object sender, EventArgs e)
        {
            try
            {
                var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
                Matr = Matr.Power(Convert.ToInt32(RaiseNum1.Text));
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++) dataGridView1[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами,\nа показатель степени целым числом."); }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Токарев А.А.");
        }

        private void InverseBtn1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != dataGridView1.ColumnCount) MessageBox.Show("Ошибка!\nМатрица должна быть квадратной.");
            else
            {
                try
                {
                    var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                    if (Matr.Determinant() == 0) MessageBox.Show("Ошибка!\nОпределитель равен нулю.");
                    else
                    {
                        Matr = Matr.Inverse();
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            for (int i = 0; i < dataGridView1.RowCount; i++) dataGridView1[j, i].Value = Matr[i, j];
                        }
                    }
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
            }
        }

        private void InverseBtn2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount != dataGridView2.ColumnCount) MessageBox.Show("Ошибка!\nМатрица должна быть квадратной.");
            else
            {
                try
                {
                    var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount);
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView2.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                    }
                    if (Matr.Determinant() == 0) MessageBox.Show("Ошибка!\nОпределитель равен нулю.");
                    else
                    {
                        Matr = Matr.Inverse();
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            for (int i = 0; i < dataGridView2.RowCount; i++) dataGridView2[j, i].Value = Matr[i, j];
                        }
                    }
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
            }
        }

        private void RaiseBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount);
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                }
                Matr = Matr.Power(Convert.ToInt32(RaiseNum2.Text));
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    for (int i = 0; i < dataGridView2.RowCount; i++) dataGridView2[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами,\nа показатель степени целым числом."); }
        }

        private void SolveS1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount - 1 != dataGridView1.RowCount || dataGridView1.ColumnCount == 1) MessageBox.Show("Нет решений.");
            else try
                {
                    var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount - 1);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount - 1; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                    var MSys = Matrix<double>.Build.Dense(dataGridView1.RowCount, 1);
                    for (int i = 0; i < dataGridView1.RowCount; i++) MSys[i, 0] = Convert.ToDouble(dataGridView1[dataGridView1.ColumnCount - 1, i].Value);
                    MSys = Matr.LU().Solve(MSys);
                    dataGridView3.ColumnCount = 1;
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    for (int i = 0; i < dataGridView1.RowCount; i++) dataGridView3[0, i].Value = MSys[i, 0];
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void TriangBtn1_Click(object sender, EventArgs e)
        {
            var Matr = Matrix<double>.Build.Dense(dataGridView1.RowCount, dataGridView1.ColumnCount);
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
                Matr = Matr.LU().U;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++) dataGridView1[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void TriangBtn2_Click(object sender, EventArgs e)
        {
            var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount);
            try
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                }
                Matr = Matr.LU().U;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++) dataGridView2[j, i].Value = Matr[i, j];
                }
            }
            catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void SolveS2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.ColumnCount - 1 != dataGridView2.RowCount || dataGridView2.ColumnCount == 1) MessageBox.Show("Нет решений.");
            else try
                {
                    var Matr = Matrix<double>.Build.Dense(dataGridView2.RowCount, dataGridView2.ColumnCount - 1);
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView2.ColumnCount - 1; j++) Matr[i, j] = Convert.ToDouble(dataGridView2[j, i].Value);
                    }
                    var MSys = Matrix<double>.Build.Dense(dataGridView2.RowCount, 1);
                    for (int i = 0; i < dataGridView2.RowCount; i++) MSys[i, 0] = Convert.ToDouble(dataGridView2[dataGridView2.ColumnCount - 1, i].Value);
                    MSys = Matr.LU().Solve(MSys);
                    dataGridView3.ColumnCount = 1;
                    dataGridView3.RowCount = dataGridView2.RowCount;
                    for (int i = 0; i < dataGridView2.RowCount; i++) dataGridView3[0, i].Value = MSys[i, 0];
                }
                catch { MessageBox.Show("Ошибка!\nВсе элементы матрицы должны быть числами."); }
        }

        private void RandBtn1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++) dataGridView1[j, i].Value = rnd.Next(Convert.ToInt32(FromNum1.Text) + 1, Convert.ToInt32(ToNum1.Text));
            }
        }

        private void RandBtn2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++) dataGridView2[j, i].Value = rnd.Next(Convert.ToInt32(FromNum2.Text) + 1, Convert.ToInt32(ToNum2.Text));
            }
        }
    }
}
