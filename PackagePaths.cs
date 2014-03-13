using System;
using System.IO;
using System.Linq;

namespace SP.ToolsUnityClient
{    
    public static class Package
    {
        public static Paths Paths;
        
        public static string Name
        {
            get {return PackageConfiguration.Name;}
        }
        
        public static string PackageResourcesFolderName
        {
            get {return PackageConfiguration.PackageResourcesFolderName;}
        }
        
        public static string FullName
        {
            get
            {
                return Name;
            }
        }
        
        static Package()
        {
            Paths = new Paths();
        }
    }
    
    public class Paths
    {
        private readonly string _packageFullPath;
        
        /// <summary>
        ///     Helper to build relative paths from elements inside this package
        /// </summary>
        public RelativePackagePaths RelativeTo;
        
        /// <summary>
        ///     Helper to build absolute paths from elements inside this package
        /// </summary>
        public AbsolutePackagePaths AbsoluteFrom;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="SP.CharacterBuilder.Paths"/> class.
        /// </summary>
        public Paths()
        {
            RelativeTo   = new RelativePackagePaths(this);
            AbsoluteFrom = new AbsolutePackagePaths(this);
            
            _packageFullPath = GetPackageFullPath();
        }
              
        public string PackageResourcesRoot
        {
            get
            {
                return Path.Combine(PackageRoot, Package.PackageResourcesFolderName);
            }    
        }
        
        public string PackageRoot
        {
            get
            {
                return _packageFullPath; 
            }    
        }
        
        public string ProjectRoot 
        {
            get
            {
                return UnityEngine.Application.dataPath.Replace("Assets", string.Empty);
            }    
        }
        
        public string AssetsRoot 
        {
            get
            {
                return UnityEngine.Application.dataPath;
            }    
        }

        private string GetPackageFullPath()
        {
            var folders = Directory.GetDirectories(UnityEngine.Application.dataPath, Package.Name, SearchOption.AllDirectories);
            
            if (folders.Count() <= 0) 
            {
                throw new Exception(
                    String.Format("Could not found any folder for the package with name '{0}'{1}We need one folder for the package inside the Unity Project", 
                        Package.Name,
                        Environment.NewLine));
            }
                    
            if (folders.Count() > 1) 
            {
                throw new Exception(
                    String.Format("Found several folders for the package with name '{0}': {1}{2}Only one folder with the same path in the same Unity Project is allowed", 
                        Package.Name, 
                        String.Join(" ", folders.ToArray()),
                        Environment.NewLine));
            }
            
            return folders.First();   
        }
    }
    
    /// <summary>
    ///     Helper methods to get full paths from relative paths inside this package
    /// </summary>
    public class AbsolutePackagePaths
    {   
        private Paths _paths;
        
        public AbsolutePackagePaths(Paths paths)
        {
            _paths = paths;
        }
        
        /// <summary>
        ///     Returns the full path given a relative path using the assets folder as root.
        /// </summary>
        /// <example>
        ///     Given the path '/Data/file1' this method returns '/<full_path_to_unity_projecct>/Assets/Data/file1'
        /// </example>
        public string AssetsFolder(string path)
        {           
            return Path.Combine(_paths.AssetsRoot, path);
        }
    
        /// <summary>
        ///     Returns the full path given a relative path using the project folder as root.
        /// </summary>
        /// <example>
        ///     Given the path '/Data/file1' this method returns '/<full_path_to_unity_project>/Data/file1'
        /// </example>
        public string ProjectFolder(string path = "")
        {
            return Path.Combine(_paths.ProjectRoot, path);
        }
        
        /// <summary>
        ///     Returns the full path given a relative path using the package folder as root.
        /// </summary>
        /// <example>
        ///     Given the path '/Data/file1' this method returns '/<full_path_to_unity_project>/<package_base>/<package_name>/Data/file1'
        /// </example>
        public string PackageFolder(string path)
        {
            return Path.Combine(_paths.PackageRoot, path);
        }
        
        /// <summary>
        ///     Returns the full path given a relative path using the test resources folder as root.
        /// </summary>
        /// <example>
        ///     Given the path '/Data/file1' this method returns '/<full_path_to_unity_project>/<package_base>/<package_name>/<test_resources>/Data/file1'
        /// </example>
        public string PackageResourcesFolder(string path)
        {
            return Path.Combine(_paths.PackageResourcesRoot, path);
        }
    }
    
    /// <summary>
    ///     Helper methods to get relative paths from files or folders inside this package
    /// </summary>
    public class RelativePackagePaths
    {
        private Paths _paths;
        
        public RelativePackagePaths(Paths paths)
        {
            _paths = paths;
        }
        
        /// <summary>
        ///     Creates a relative path by removing the substring that matches
        ///     the path to this unity project root.
        /// </summary>
        /// <example>
        ///     Given the unity project at 
        ///     '/test/my_unity_project/' 
        ///     if we pass to this method the full path
        ///     '/test/my_unity_project/Assets/animation1.fbx'
        ///     It will return the relative path:
        ///     'Assets/animation1.fbx'
        /// </example>
        private string RemoveFullPath(string path)
        {
            return path.Replace(_paths.ProjectRoot, string.Empty);
        }
        
        /// <summary>
        ///     Creates a relative path using the unity project folder as root
        /// </summary>
        /// <example>
        ///     Given the path 'Data/file1'
        ///     this method returns 'Data/file1' 
        /// </example>
        public string ProjectFolder(string path)
        {
            return RemoveFullPath(path);
        }

        /// <summary>
        ///     Creates a relative path using the unity assets folder as root
        /// </summary>
        /// <example>
        ///     Given the path 'Data/file1'
        ///     this method returns 'Assets/Data/file1' 
        /// </example>
        public string AssetsFolder(string path)
        {
            return Path.Combine("Assets", RemoveFullPath(path.Replace("Assets/", string.Empty)));
        }
        
        /// <summary>
        ///     Creates a relative path using the package folder as root
        /// </summary>
        /// <example>
        ///     Given the path 'Data/file1'
        ///     this method returns 'Assets/<package_folder>/Data/file1' 
        /// </example>
        public string PackageFolder(string path)
        {
            return Path.Combine(AssetsFolder(_paths.PackageRoot), RemoveFullPath(path));
        }
        
        /// <summary>
        ///     Creates a relative path using the package folder as root
        /// </summary>
        /// <example>
        ///     Given the path 'Data/file1'
        ///     this method returns 'Assets/<package_folder>/<tests_resources_folder>/Data/file1' 
        ///  
        /// </example>
        public string PackageResourcesFolder(string path)
        {
            return Path.Combine(PackageFolder(Package.PackageResourcesFolderName), RemoveFullPath(path));
        }
    }
    
}
