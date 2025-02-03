using Microsoft.EntityFrameworkCore;

namespace SalesApp.Infrastructure.DataContext
{
    public static class SortUtils
    {
        public static IQueryable<T> OrderWithText<T>(this IQueryable<T> source, string text)
        {
            ArgumentNullException.ThrowIfNull(source);

            if(string.IsNullOrEmpty(text))
            {
                return source;
            }

            text = text.Trim();
            bool ordered = false;

            string[] fields = text.Split(',');
            foreach(string fieldData in fields)
            {
                string[] data = fieldData.Trim().Split(' ');
                string fieldName = "";
                string sortMode = "asc";
                if(data.Length < 1 || data.Length > 2)
                {
                    continue;
                }

                fieldName = data[0];

                if(data.Length == 2)
                {
                    if(data[1] == "asc" || data[1] == "desc")
                    {
                        sortMode = data[1];
                    } else
                    {
                        continue;
                    }
                }
                if(ordered)
                {
                    if(sortMode == "asc")
                    {
                        source = (source as IOrderedQueryable<T>).ThenBy(e => EF.Property<object>(e, fieldName));
                    } else
                    {
                        source = (source as IOrderedQueryable<T>).ThenByDescending(e => EF.Property<object>(e, fieldName));
                    }
                } else
                {
                    if(sortMode == "asc")
                    {
                        source = source.OrderBy(e => EF.Property<object>(e, fieldName));
                    } else
                    {
                        source = source.OrderByDescending(e => EF.Property<object>(e, fieldName));
                    }
                    ordered = true;
                }
            }

            return source;
        }
    }
}
