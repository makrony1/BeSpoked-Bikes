import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getSales } from '../../services/api';

const Sales = () => {
    const [sales, setsales] = useState([]);

    useEffect(() => {
        fetchItems();
    }, []);

    const fetchItems = async () => {
        const response = await getSales();
        setsales(response.data);
    };

    return (
        <div className="container mt-4">
            <h2>Sales for the recent 3 months</h2>
            <div className='text-right'>
                <Link className="btn btn-primary float-end" to={`/sales/create`}>Create</Link>
            </div>
            <div>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Product</th>
                            <th scope="col">Customer</th>
                            <th scope="col">Salesperson</th>
                            <th scope="col">Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {sales.map(item =>
                        (<tr>
                            <td>{item.productName}</td>
                            <td>{item.customerName}</td>
                            <td>{item.salespersonName}</td>
                            <td>{new Date(item.salesDate).toLocaleDateString()}</td>
                        </tr>)
                        )}

                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default Sales;
