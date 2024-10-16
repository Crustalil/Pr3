namespace Lib_2
{
    public class RaschetInMatr
    {
        /// <summary>
        /// Расчет суммы и произведения K-го столбца матрицы
        /// </summary>
        /// <param name="matr"></param>
        /// <param name="K"></param>
        /// <param name="sum"></param>
        /// <param name="product"></param>
        public static void SumAndProduct (int[,] matr, int K, out int sum,  out int product)
        {
            sum = 0;
            product = 1;
            for (int i = 0; i < matr.GetLength (0); i++)
            {
                sum += matr[i, K-1];
                product *= matr[i,K-1];
            }
        }
    }

}
