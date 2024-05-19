import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { createSales, getProducts, getCustomers, getSalespeople } from '../../services/api';
import SearchableDropdown from '../../components/SearchableDropdown';

const CreateSales = () => {
  const navigate = useNavigate();
  const [productOption, setProductOption] = useState([]);
  const [customerOption, setCustomerOption] = useState([]);
  const [salespeopleOption, setSalespeopleOption] = useState([]);
  const [sales, setSales] = useState({
    productId: '',
    salespersonId: '',
    customerId: ''
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  useEffect(()=>{
    fetchProducts();
    fetchCustomers();
    fetchsalespeople();
  },[]);

  const fetchsalespeople = async () => {
    const response = await getSalespeople();
    console.log(response.data)
    var options = response.data.map(p=> {return {Id: p.id, Text:p.firstName+" "+p.lastName}});
    console.log(options)
    setSalespeopleOption(options);
};

  const fetchProducts = async () => {
    const response = await getProducts();
    console.log(response.data)
    var data = response.data.filter(p=>p.qtyOnHand>0);
    var options = data.map(p=> {return {Id: p.id, Text:p.name}});
    console.log(options)
    setProductOption(options);
};

const fetchCustomers = async () => {
    const response = await getCustomers();
    console.log(response.data)
    var options = response.data.map(p=> {return {Id: p.id, Text:p.firstName+" "+p.lastName}});
    console.log(options)
    setCustomerOption(options);
};

const handleProductChange = async (e) =>{
    sales.productId = e.Id;
  };
  const handleSalespersonChange = async (e) =>{
    sales.salespersonId = e.Id;
  };
  const handleCustomerChange = async (e) =>{
    sales.customerId = e.Id;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
        await createSales(sales);
      navigate('/sales');
    } catch (err) {
        setError(JSON.stringify(err.response.data.errors));
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container mt-4">
        <div className='text-danger'>{error}</div>
      <h2>Create Product</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="Product">Product</label>
          <SearchableDropdown options={productOption} onSelect={handleProductChange} />
        </div>

        <div className="form-group">
          <label htmlFor="Customer">Customer</label>
          <SearchableDropdown options={customerOption} onSelect={handleCustomerChange} />
        </div>

        <div className="form-group">
          <label htmlFor="salesperson">Salesperson</label>
          <SearchableDropdown options={salespeopleOption} onSelect={handleSalespersonChange} />
        </div>
        <br/>
        <button type="submit" className="btn btn-primary">Create Product</button>
      </form>
    </div>
  );
};

export default CreateSales;
