using System.Collections.Generic;
using System.Linq;

namespace Share
{
    internal static class Comparator
    {
        private static bool Equal(this Dictionary<string, string> target, Dictionary<string, string> orig)
        {
            return target != null && orig?.All(p => target.ContainsKey(p.Key)) == true;
        }

        /// <summary>
        /// Fills the target with missing keys from orig,
        /// Returns if the file was modified.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="orig"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static bool FillKeys(this Dictionary<string, string> target, Dictionary<string, string> orig,ILogger logger)
        {
            if (Equal(target, orig))
            {
                return true;
            }
            if (target == null)
            {
                logger.PrintError("Can't fill file as it is NULL!");
                return false;
            }
            if (orig == null)
            {
                logger.PrintError("Can't fill file as the original file is NULL!");
                return false;
            }
            var diff = orig.Keys.Except(target.Keys).ToList();
            foreach (var key in diff)
            {
                logger.PrintWarning("Adding key \"{0}\" with English value.",key);
                target.Add(key,orig[key]);
            }
            return false;
        }

        public static void AddKeys(this Dictionary<string, string> target, Dictionary<string, string> orig,
            ILogger logger)
        {
            if (orig == null)
            {
                logger.PrintError("Can't fill file as the original file is NULL!");
                return;
            }
            if(target == null)
                target=new Dictionary<string, string>();
            var keys = orig.Keys.ToList();
            foreach (var key in keys)
            {
                target.Add(key,null);
            }

        }
        public static void SortDict(this Dictionary<string, string> target, Dictionary<string, string> orig, ILogger logger)
        {
            if (target == null)
            {
                logger.PrintError("Can't sort file as it is NULL!");
                return;
            }
            if (orig == null)
            {
                logger.PrintError("Can't sort file as the original file is NULL!");
                return;
            }
            var bckp = new Dictionary<string,string>(target);
            target.Clear();
            foreach (var pair in orig)
            {
                target.Add(pair.Key,bckp[pair.Key]);
                bckp.Remove(pair.Key);
            }
            var orderBy = bckp.OrderBy(t => t.Key);
            foreach (var pair in orderBy)
            {
                if (target.ContainsKey(pair.Key))
                {
                    logger.PrintWarning("Duplicate key \"{0}\" while sorting the dictionary! This should never happen!",pair.Key);
                    continue;
                }
                target.Add(pair.Key,pair.Value);
            }
        }
    }
}
