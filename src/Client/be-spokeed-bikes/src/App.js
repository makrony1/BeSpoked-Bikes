import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar';
import MyList from './components/List';
import Products from './components/products/Products';
import EditProduct from './components/products/EditProduct';
import CreateProduct from './components/products/CreateProduct';
import Customers from './components/customers/Customers';
import Salesperson from './components/salesperson/Salesperson';
import EditSalesperson from './components/salesperson/EditSalesperson';
import Sales from './components/sales/Sales';
import CreateSales from './components/sales/CreateSales';
const App = () => {
  return (
    <BrowserRouter>
      <Navbar />
      
      <Routes>
        <Route exact path="/" element={<Products/>} />
        <Route exact path="/product" element={<Products/>} />
        <Route exact path="/customer" element={<Customers/>} />
        <Route exact path="/product/edit/:id" element={<EditProduct/>} />
        <Route path="/product/create" element={<CreateProduct/>} />
        <Route path="/salesperson" element={<Salesperson/>} />
        <Route path='/salesperson/edit/:id' element={<EditSalesperson/>}/>
        <Route path='/sales' element={<Sales/>}/>
        <Route path='/sales/create' element={<CreateSales/>}/>
      </Routes>
    </BrowserRouter>
    
  );
};

export default App;
