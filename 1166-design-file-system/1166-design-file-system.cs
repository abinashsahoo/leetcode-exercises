public class FileSystem 
{
    private readonly Dictionary<string, int> _files = new();

    public FileSystem() 
    {
        
    }
    
    public bool CreatePath(string path, int value) 
    {
        if(string.IsNullOrEmpty(path) || path == "/" || !path.StartsWith("/"))
        {
            return false;
        }
        
        if(_files.ContainsKey(path))
        {
            return false;
        }
        
        if(path.LastIndexOf("/") > 0)
        {
            string parentPath = path.Substring(0, path.LastIndexOf("/"));
            if(!_files.ContainsKey(parentPath))
            {
                return false;
            }            
        }
        
        _files.Add(path, value);
        return true;
    }
    
    public int Get(string path) 
    {
        if(!_files.ContainsKey(path))
        {
            return -1;
        }
        
        return _files[path];
    }
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * bool param_1 = obj.CreatePath(path,value);
 * int param_2 = obj.Get(path);
 */