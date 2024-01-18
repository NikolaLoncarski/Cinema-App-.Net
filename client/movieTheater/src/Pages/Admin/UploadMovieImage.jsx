import { useState } from 'react';


import { apiPostFile } from '../../utils/axios';

const UploadMovieImage = () => {
 const [file, setFile] = useState(null);
 const [fileName, setFileName] = useState('');
 const [errorMessage, setErrorMessage] = useState('');

 const handleFileChange = (e) => {
   const selectedFile = e.target.files[0];
   setFile(selectedFile);

   console.log(selectedFile)
 };

 const handleUpload = async () => {
   setErrorMessage('');

   if (!file) {
     setErrorMessage('Please select a file');
     return;
   }

   const formData = new FormData();
   formData.append('File', file);
   formData.append('FileName', fileName);

   try {
     const response = await apiPostFile('api/Image/Upload',  formData);

   
   } catch (error) {
     console.error(error)
   }
 };

 return (
   <div className='mt-48 w-96 relative flex flex-col w-6/12 text-gray-700 bg-white shadow-2xl bg-clip-border rounded-xl m-16 max-w-screen-xl  h-96   mx-auto px-4  gap-8'>
     <input type="file"    className=" block p-2.5 w-11/12 z-20 text-sm text-yellow-900 bg-yellow-50 rounded-lg  border-s-yellow-50 border-s-2 border border-yellow-300 focus:ring-yellow-500 focus:border-yellow-500 dark:bg-yellow-700 dark:border-s-yellow-700  dark:border-yellow-600 dark:placeholder-yellow-400 dark:text-white dark:focus:border-yellow-500" placeholder="File" required onChange={handleFileChange} />

     <input type='text'   className="block p-2.5 w-11/12 z-20 text-sm text-yellow-900 bg-yellow-50 rounded-lg border-s-yellow-50 border-s-2 border border-yellow-300 focus:ring-yellow-500 focus:border-yellow-500 dark:bg-yellow-700 dark:border-s-yellow-700  dark:border-yellow-600 dark:placeholder-yellow-400 dark:text-white dark:focus:border-yellow-500" placeholder="File Name" required onChange={(e)=>setFileName(e.target.value)} />
     <input    className="w-fit bg-yellow-500 hover:bg-yellow-600  text-gray-700  font-semibold hover:text-white py-2 px-4 border border-gray-500 hover:border-transparent  cursor-pointer h-12 " type='button'  value='Upload Movie Image' onClick={handleUpload}/>
     {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
   </div>
 );
};

export default UploadMovieImage;
