import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getSalespeople } from '../../services/api';

const Salesperson = () => {
    const [persons, setSalesperson] = useState([]);

    useEffect(() => {
        fetchItems();
    }, []);

    const fetchItems = async () => {
        const response = await getSalespeople();
        //console.(response);
        setSalesperson(response.data);
    };
    return (
        <div className="container mt-4">
            <h2>Salesperson</h2>
            <div>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Name</th>
                            <th scope="col">Address</th>
                            <th scope="col">Phone</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {persons.map(item =>
                        (<tr>
                            <td>{item.firstName} {item.lastName}</td>
                            <td>{item.address}</td>
                            <td>{item.phone}</td><td>
                                <div>
                                    <Link className="btn btn-link btn-sm mr-2" to={`/salesperson/edit/${item.id}`}>Edit</Link>
                                </div>
                            </td>

                        </tr>)
                        )}

                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default Salesperson;
