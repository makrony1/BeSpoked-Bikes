import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getCustomers } from '../../services/api';

const Customers = () => {
  const [customers, setCustomers] = useState([]);

  useEffect(() => {
    fetchItems();
  }, []);

  const fetchItems = async () => {
    const response = await getCustomers();
    setCustomers(response.data);
  };

  return (
    <div className="container mt-4">
      <h2>Customers</h2>
      <div>
      <table class="table">
  <thead>
    <tr>
      <th scope="col">First Name</th>
      <th scope="col">Last Name</th>
      <th scope="col">Phone</th>
      <th scope="col">Address</th>
      <th scope="col">Join Date</th>
    </tr>
  </thead>
  <tbody>
{customers.map(item=>
    (<tr>
      <td>{item.firstName}</td>
      <td>{item.lastName}</td>
      <td>{item.phone}</td>
      <td>{item.address}</td>
      <td>{new Date(item.startDate).toLocaleDateString()}</td>
    </tr>)
    )}
      
  </tbody>
</table>
      </div>
    </div>
  );
};

export default Customers;
