import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getSalespeople, getSalesperson, updateSalesperson } from '../../services/api';
import SearchableDropdown from '../../components/SearchableDropdown';

const EditSalesperson = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [salespeople, setSalespeope] = useState([]);
  const [selectedOption, setSelectedOption] = useState("");
  const [salesperson, setSalesperson] = useState(
    {
        "id": "",
        "firstName": "",
        "lastName": "",
        "address": "",
        "phone": "",
        "startDate": "",
        "terminationDate": "",
        "managerId": ""
      }
  );
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [currentManager, setManager ]= useState("");;
  useEffect(() => {
    const fetchsalespeople = async () => {
        const allpeople = await getSalespeople();
        var posiblemanager = allpeople.data.filter(p=>p.id!=id);
        var options = posiblemanager.map(pp=>{return {Text: pp.firstName+" "+ pp.lastName, Id : pp.id}})
        setSalespeope(options);
        if(salesperson.managerId){
            setSelectedOption(options.find(o=>o.Id==salesperson.managerId).Text)

        }

        
    };

    const fetchSalesperson = async () => {
      try {
        const response = await getSalesperson(id);
        setSalesperson(response.data);
        fetchsalespeople();
        setLoading(false);
      } catch (err) {
        setError(JSON.stringify(err.response.data.errors));
        setLoading(false);
      }
    };
    
    fetchSalesperson();
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    console.log(e.target);
    setSalesperson({ ...salesperson, [name]: value });
  };

  const handleSelect = async (e) =>{
    console.log(e);
    setSelectedOption(e.Text);
    salesperson.managerId = e.Id;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
        console.log(salesperson);
        await updateSalesperson(id, salesperson);
      navigate('/salesperson');
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
      <h2>Edit Salesperson</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="fname">First Name</label>
          <input
            type="text"
            className="form-control"
            id="fname"
            name="firstName"
            value={salesperson.firstName}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="lname">Last Name</label>
          <input
            type="text"
            className="form-control"
            id="lname"
            name="lastName"
            value={salesperson.lastName}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="address">Address</label>
          <input
            type="text"
            className="form-control"
            id="address"
            name="address"
            value={salesperson.address}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="phone">phone</label>
          <input
            type="text"
            className="form-control"
            id="phone"
            name="phone"
            value={salesperson.phone}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="manager">Manager</label>
          <SearchableDropdown options={salespeople} onSelect={handleSelect} />
      {selectedOption && <div className="mt-3">Selected: {selectedOption}</div>}
        </div>
        <button type="submit" className="btn btn-primary">Update Salesperson</button>
      </form>
    </div>
  );
};

export default EditSalesperson;
