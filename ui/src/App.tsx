import React from 'react';
import EmployeeList from './UI/customComponents/EmployeeList';
import './../src/App.css';
import 'react-toastify/dist/ReactToastify.css';


const App = () => {
  return (
    <div className="App">
      <EmployeeList/>
    </div>
  );
}

export default App;
