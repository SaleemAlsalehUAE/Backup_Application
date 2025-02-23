﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace MYCPF
{
   /// //http://www.pinvoke.net/default.aspx/kernel32.CopyFileEx
    /// <summary>
    /// Copies a list of files or a directory tree to a destination
    /// 
    /// Support for GUI is implamented by the ICopyFilesDiag interface
    /// and passed to the class in the copy() method.
    /// </summary>
    public class CopyFiles
    {

        // Variables
        public static bool completed=false;
        public static int t=0;
        public static bool copying=false;
        private List<String> files = new List<String>();
        private List<String> newFilenames = new List<String>();
        private List<ST_CopyFileDetails> filesCopied = new List<ST_CopyFileDetails>();
        private Int32 totalFiles = 0;
        private Int32 totalFilesCopied = 0;
        private String destinationDir = "";
        private String sourceDir = "";
        private String currentFilename;
        private Boolean cancel = false;
        private IAsyncResult CopyResult;
        private DEL_CopyFiles delCopy;
        private ICopyFilesDiag digWindow;

        // Structurs
        public struct ST_CopyFileDetails
        {

            String OriginalURI;
            String NewURI;

            // Constructor
            public ST_CopyFileDetails(String FromURI, String ToURI)
            {
                OriginalURI = FromURI;
                NewURI = ToURI;
            }

        }

        // Enums
        // These Enums are used for the windows CopyFileEx function
        [Flags]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }
        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }
        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }

        // Events
        public event DEL_copyComplete EV_copyComplete;
        public event DEL_copyCanceled EV_copyCanceled;

        // Delegates
        private delegate CopyProgressResult CopyProgressRoutine(Int64 TotalFileSize, Int64 TotalBytesTransferred, Int64 StreamSize, Int64 StreamBytesTransferred, UInt32 dwStreamNumber, CopyProgressCallbackReason dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);
        private delegate CopyProgressResult DEL_CopyProgressHandler(Int64 total, Int64 transferred, Int64 streamSize, Int64 StreamByteTrans, UInt32 dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);
        private delegate void DEL_CopyFiles();
        private delegate void DEL_ShowDiag(ICopyFilesDiag diag);
        private delegate void DEL_HideDiag(ICopyFilesDiag diag);
        private delegate void DEL_CopyfilesCallback(IAsyncResult r);

        public delegate void DEL_cancelCopy();
        public delegate void DEL_copyComplete();
        public delegate void DEL_copyCanceled(List<ST_CopyFileDetails> filescopied);

        // Constructors
        public CopyFiles(String source, String destination)
        {
            //As the directory tree might be large we work out the
            //files in the threaded call Copyfiles()
            sourceDir = source;
            destinationDir = destination;
        }
        public CopyFiles(List<String> sourceFiles, String destination)
        {

            //The sourceDir does not need to be set if the user is supplying a 
            //list of files.
            //
            //Example :
            //      Source                      Destination
            //      c:\Temp1\Test.txt           c:\DestFolder\Test.txt
            //      c:\temp2\temp1\test1.txt    c:\DestFolder\Test1.txt
            //      c:\temp3\blah\Test.txt      c:\DestFolder\Test (2).txt
            //
            //This is worked out in CheckFilenames()
            files = sourceFiles;
            totalFiles = files.Count;
            destinationDir = destination;
        }

        // Kernal32 Calls
        // Unsafe is need to show that we are using 
        // pointers which are classed as "unsafe" in .net
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern unsafe bool CopyFileEx(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, IntPtr lpData, Boolean* pbCancel, CopyFileFlags dwCopyFlags);

        // Methods
        private List<String> GetFiles(String sourceDir)
        {



            //files.Remove("$RECYCLE.BIN");
            //files.Remove("System Volume Information");
            // Variables
           
           
                List<String> foundFiles = new List<String>();
                String[] fileEntries;
                String[] subdirEntries;

                //Add root files in this DIR to the list
                fileEntries = System.IO.Directory.GetFiles(sourceDir);
                foreach (String filename in fileEntries)
                {
                    string newfn = filename;
                    //if (filename.Length >= 259)
                    //{
                    //    newfn = filename.Remove(filename.Length - 53, 48);
                    //    int fn = filename.Length;
                    //    int nfn = newfn.Length;
                    //    File.Move(filename, newfn + DateTime.Now.Millisecond);
                    //    foundFiles.Add(newfn);
                    //}
                    //else
                    //{
                    //    foundFiles.Add(filename);
                    //}

                    foundFiles.Add(filename);
                }

                //Loop the DIR's in the current DIR
                subdirEntries = System.IO.Directory.GetDirectories(sourceDir);
            
            //saleem
            List<string>Tmpsub=new List<string>();
            for (int i = 0; i < subdirEntries.Length;i++ ) {
                if (!(subdirEntries[i].Contains("$RECYCLE.BIN") || subdirEntries[i].Contains("System Volume Information"))) {
                    Tmpsub.Add(subdirEntries[i]);
                }
            }
            subdirEntries = Tmpsub.ToArray();


            //saleem

                foreach (string subdir in subdirEntries)
                {

                    //Dont open Folder Redirects as this can end up in an infinate loop
                    if ((System.IO.File.GetAttributes(subdir) &
                         System.IO.FileAttributes.ReparsePoint) !=
                         System.IO.FileAttributes.ReparsePoint)
                    {
                        //Run recursivly to follow this DIR tree 
                        //adding all the files along the way
                        foundFiles.AddRange(GetFiles(subdir));
                    }

                }

                return foundFiles;
            }
       
        
        private CopyProgressResult CopyProgressHandler(Int64 total, Int64 transferred, Int64 streamSize, Int64 StreamByteTrans, UInt32 dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
        {
            //Check to see if there is a dialog window to use
            if (digWindow != null)
            {
                //Are we going to send the update on the correct thread?
                if (digWindow.SynchronizationObject != null && digWindow.SynchronizationObject.InvokeRequired)
                {
                    digWindow.SynchronizationObject.Invoke(new CopyProgressRoutine(CopyProgressHandler),
                                new Object[] { total, transferred, streamSize, StreamByteTrans, dwStreamNumber, reason, hSourceFile, hDestinationFile, lpData });
                }
                else
                {
                    digWindow.update(totalFiles, totalFilesCopied, total, transferred, currentFilename);
                }

            }
            return CopyProgressResult.PROGRESS_CONTINUE;
        }
        //private void ShowDiag(ICopyFilesDiag diag)
        //{
        //    //Check to see if there is a dialog window to use
        //    if (digWindow != null)
        //    {
        //        //Are we going to send the update on the correct thread?
        //        if (digWindow.SynchronizationObject != null && digWindow.SynchronizationObject.InvokeRequired)
        //        {
        //            digWindow.SynchronizationObject.Invoke(new DEL_ShowDiag(ShowDiag),
        //                new Object[] { diag });
        //        }
        //        else
        //        {
        //            diag.Show();
        //        }
        //    }
        //}
        //private void HideDiag(ICopyFilesDiag diag)
        //{
        //    //Check to see if there is a dialog window to use
        //    if (digWindow != null)
        //    {
        //        //Are we going to send the update on the correct thread?
        //        if (digWindow.SynchronizationObject != null && digWindow.SynchronizationObject.InvokeRequired)
        //        {
        //            digWindow.SynchronizationObject.Invoke(new DEL_HideDiag(HideDiag),
        //                new Object[] { diag });
        //        }
        //        else
        //        {
        //            diag.Hide();
        //            cancel = false;
        //        }
        //    }
        //}
        private void CancelCopy()
        {
            cancel = true;
            OnCopyCanceled();
        }
        private void Copyfiles()
        {
            copying = true;
            Int32 index = 0;

            //Show the dialog box and hook into its cancel event if
            //a dialog box has been given
            if (digWindow != null)
            {
                digWindow.EN_cancelCopy += CancelCopy;
                //ShowDiag(digWindow);
            }

            //If we have been a sourceDIR then find all the files to copy
            if (sourceDir != "")
            {
                files = GetFiles(sourceDir);

            }
            else
            {
                CheckFilenames();
            }
            totalFiles = files.Count;

            //Loop each file and copy it.
            foreach (String filename in files.ToArray())
            {
                String[] filepath;
                String tempFilepath;
                String tempDirPath = "";

                //If we have a source directory, strip that off the filename
                if (sourceDir != "")
                {
                    //tempFilepath = filename;
                    //tempFilepath = tempFilepath.Replace(sourceDir, "");
                    //tempFilepath = System.IO.Path.Combine(destinationDir, tempFilepath);



                        tempFilepath = filename.Remove(0, 2);
                        tempFilepath = tempFilepath.Replace(sourceDir, "");
                        tempFilepath = destinationDir + tempFilepath;
                }else{
                    tempFilepath = destinationDir + newFilenames[index];
                }
                    //tempFilepath = tempFilepath.Replace("\\", "");
                  

                
                //otherwise strip off all the folder path
         

                //Save the new DIR path and check the DIR exsits,
                //if it does not then create it so the files can copy
                filepath = tempFilepath.Split('\\');
                for (int i = 0; i < filepath.Length - 1; i++)
                {
                    tempDirPath += filepath[i] + "\\";
                }
                if (!System.IO.Directory.Exists(tempDirPath))
                {
                    System.IO.Directory.CreateDirectory(tempDirPath);
                }

                //Have be been told to stop copying files
                if (cancel)
                {
                    break;
                }

                //Set the file thats just about to get copied
                currentFilename = filename;

                //Unsafe is need to show that we are using 
                //pointers which are classed as "unsafe" in .net
                //
                //CopyFileEx needs a pointer to the cancel boolean, it checks this
                //constantly as the file copies, if it gets set to true it will stop
                //
                //Note :
                //  fixed is used to get the memory pointer of our local boolean.
                //  It is then saved in a pointer (declared like a normal type but
                //  with a * at the end)
                //  
                //  We can then pass this memory address to the Kernal32 call.
                
                // saleem
                // checking file name lenght if > 255 to rename the file then copy it // 
                //if (filename.Length >= 255)
                //{
                //    string newfn = filename.Remove(filename.Length-200,20);
                //    File.Move(filename, newfn);
                //    unsafe
                //    {
                //        fixed (Boolean* cancelp = &cancel)
                //        {
                //            CopyFileEx(newfn, tempFilepath, new CopyProgressRoutine(this.CopyProgressHandler), IntPtr.Zero, cancelp, 0);
                //        }
                //    }
                //}
          
                    unsafe
                    {
                        fixed (Boolean* cancelp = &cancel)
                        {
                            CopyFileEx(filename, tempFilepath, new CopyProgressRoutine(this.CopyProgressHandler), IntPtr.Zero, cancelp, 0);
                        }
                    }
                
                filesCopied.Add(new ST_CopyFileDetails(filename, tempFilepath));
                totalFilesCopied += 1;
                t = totalFilesCopied;
                index += 1;

            }

        }
        private void OnCopyComplete()
        {
            copying = false;
            digWindow.bupcompleted();
            if (EV_copyComplete != null)
            {
               
                EV_copyComplete();
               
            }
        }
        private void OnCopyCanceled()
        {
            copying = false;
            digWindow.bupcanceled();
            if (EV_copyCanceled != null)
            {
                EV_copyCanceled(filesCopied);
            }
        }
        private void CheckFilenames()
        {
            // Variables
            String[] fileNames = new String[files.Count];
            List<String> tempFileNameArr;
            Int32 index = 0;
            Int32 innerIndex = 0;
            Int32 filenameIndex = 0;
            Int32 filenameNumber = 0;

            //Load filenames into an array
            foreach (String tempFileName in files)
            {
                string newfn = tempFileName;
                //if (tempFileName.Length >= 255)
                //{
                //    newfn = tempFileName.Remove(tempFileName.Length - 15, 9);
                //    File.Move(tempFileName, DateTime.Now.Second+newfn + DateTime.Now.Millisecond);
                   

                //    //newfn = tempFileName.Remove(tempFileName.Length - 200, 6);
                //    //File.Move(tempFileName, newfn);
                //}

                fileNames[index] = System.IO.Path.GetFileName(newfn);
                index += 1;
            }

            //Loop each filename in the array
            index = 0;
            foreach (String originalFilename in fileNames)
            {

                //See if this filename is repeated in the list
                innerIndex = 0;
                filenameNumber = 2;
                foreach (String dupeFilename in fileNames)
                {
                    //dont compair the same index!
                    if (innerIndex != index)
                    {

                        if (originalFilename == dupeFilename)
                        {
                            //insert the duplicate number into the new filename e.g (2) and clear
                            //the current name.
                            tempFileNameArr = new List<String>(fileNames[innerIndex].Split('.'));
                            tempFileNameArr.Insert(tempFileNameArr.Count - 1, "[*REMOVEME*] (" + filenameNumber + ")");
                            fileNames[innerIndex] = "";

                            //Rebuild the new filename
                            filenameIndex = 0;
                            foreach (String newFilename in tempFileNameArr)
                            {

                                //put a dot before the file extension
                                if (filenameIndex == tempFileNameArr.Count - 1)
                                { fileNames[innerIndex] += "."; }

                                //append the new filename
                                fileNames[innerIndex] += newFilename.Replace("[*REMOVEME*]", "");

                                //only add a . if its not the injected portion e.g (2)
                                if ((filenameIndex < tempFileNameArr.Count - 3 && newFilename.StartsWith("[*REMOVEME*]") == false))
                                { fileNames[innerIndex] += "."; }

                                filenameIndex += 1;
                            }

                            //Trim any trailing .'s
                            fileNames[innerIndex].TrimEnd(new Char[] { '.' });
                            filenameNumber += 1;
                        }
                    }
                    innerIndex += 1;
                }
                index += 1;

            }

            //Update the list of new filenames.
            newFilenames = new List<String>(fileNames);

        }

        //Copy the files
        public void Copy()
        {
            Copyfiles();
        }
        public void CopyAsync(ICopyFilesDiag diag)
        {
            digWindow = diag;

            if (digWindow != null && digWindow.SynchronizationObject == null)
            {
                throw new Exception("Dialog window sent with no SynchronizationObject");
            }

            delCopy = new DEL_CopyFiles(Copyfiles);
            CopyResult = delCopy.BeginInvoke(CopyfilesCallback, null);
        }

        // Async Callbacks
        private void CopyfilesCallback(IAsyncResult r)
        {
            //Kill off the thread as its finished.
            delCopy.EndInvoke(CopyResult);
            //HideDiag(digWindow);
            OnCopyComplete();
        }

    }

    //The interface for the Dialog the CopyFiles class uses.
    public interface ICopyFilesDiag
    {
        //needed to sync the CopyClass update events with the dialog thread
        System.ComponentModel.ISynchronizeInvoke SynchronizationObject { get; set; }

        //This event should fire when you want to cancel the copy
        event CopyFiles.DEL_cancelCopy EN_cancelCopy;

        //This is how the CopyClass will send your dialog information about
        //the transfer
        void update(Int32 totalFiles, Int32 copiedFiles, Int64 totalBytes, Int64 copiedBytes, String currentFilename);
        void bupcompleted();
        void bupcanceled();
       // void Show();
       // void Hide();

    }

}
