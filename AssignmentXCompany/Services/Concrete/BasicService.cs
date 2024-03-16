namespace AssignmentXCompany.Services.Concrete
{
    public static class BasicService
    {
        public static double Avarage(params int[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new Exception("array length cannot be zero");

            var sum = 0;
            foreach (var i in array)
            {
                sum += i;
            }
            var avarage = (double)sum / array.Length;
            return avarage;
        }
    }
}
