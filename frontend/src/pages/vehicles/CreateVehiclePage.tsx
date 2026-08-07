import { useEffect, useState } from "react";
import api from "../../services/api";

export function CreateVehiclePage() {
  const [brand, setBrand] = useState("");
  const [model, setModel] = useState("");
  const [year, setYear] = useState("");
  const [plateNumber, setPlateNumber] = useState("");
  const [dailyRate, setDailyRate] = useState("");
  // const [categories, setCatgeories] = useState([]);
  const [categoryId, setCategoryId] = useState("");

  // useEffect(() => {
  //   async function loadCategories() {
  //     const response = await api.get("/vehicle/category");

  //     // setCatgeories(response.data);
  //   }
  //   loadCategories();
  // });

  return (
    <div className="p-6 max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6">Add New Vehicle</h1>

      <div className="mb-4">
        <label className="block text-sm font-medium mb-1">Brand</label>
        <input
          type="text"
          value={brand}
          onChange={(e) => setBrand(e.target.value)}
          className="w-full border rounded-lg px-3 py-2"
        />
      </div>
      <div className="mb-4">
        <label className="block text-sm font-medium mb-1">Model</label>
        <input
          type="text"
          value={model}
          onChange={(e) => setModel(e.target.value)}
          className="w-full border rounded-lg px-3 py-2"
        />
      </div>
      <div className="mb-4">
        <label className="block text-sm font-medium mb-1">Year</label>
        <input
          type="number"
          value={year}
          onChange={(e) => setYear(e.target.value)}
          className="w-full border rounded-lg px-3 py-2"
        />
      </div>
      <div className="mb-4">
        <label className="block text-sm font-medium mb-1">Plate Number</label>
        <input
          type="text"
          value={plateNumber}
          onChange={(e) => setPlateNumber(e.target.value)}
          className="w-full border rounded-lg px-3 py-2"
        />
      </div>
      <div className="mb-4">
        <label className="block text-sm font-medium mb-1">Daily Rate</label>
        <input
          type="number"
          value={dailyRate}
          onChange={(e) => setDailyRate(e.target.value)}
          className="w-full border rounded-lg px-3 py-2"
        />
      </div>
      <label className="block tex-sm font-medium mb-1">Category</label>
      <select
        value={categoryId}
        onChange={(e) => setCategoryId(e.target.value)}
        className="w-full border rounded-lg px-3 py-2"
      ></select>
    </div>
  );
}
