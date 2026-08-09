import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import api from "../../services/api";

interface Category {
  categoryId: number;
  name: string;
  description?: string;
  createdAt?: string;
}

export function EditVehiclePage() {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const [brand, setBrand] = useState("");
  const [model, setModel] = useState("");
  const [year, setYear] = useState("");
  const [plateNumber, setPlateNumber] = useState("");
  const [dailyRate, setDailyRate] = useState("");
  const [categoryId, setCategoryId] = useState("");
  const [categoryName, setCategoryName] = useState("");
  const [categories, setCategories] = useState<Category[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadVehicle() {
      const response = await api.get(`/vehicle/${id}`);
      const vehicle = response.data.data;
      console.log("Vehicle loaded:", vehicle);

      setBrand(vehicle.brand);
      setModel(vehicle.model);
      setYear(vehicle.year?.toString() || ""); // Convert to string
      setPlateNumber(vehicle.plateNumber);
      setDailyRate(vehicle.dailyRate?.toString() || ""); // Convert to string
      setCategoryId(vehicle.categoryId?.toString() || "");
      setCategoryName(vehicle.categoryName || "");
      setLoading(false);
    }

    async function loadCategories() {
      const response = await api.get("/vehicle/category");

      setCategories(response.data.data || response.data);
    }

    loadVehicle();
    loadCategories();
  }, [id]); // Re-run every time id changes &  [] Empty = never re-run /run once

  if (loading || categories.length === 0) {
    return <div className="p-6">Loading vehicle...</div>;
  }

  // Add this after the loading check
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    await api.put(`/vehicle/${id}`, {
      brand,
      model,
      year: Number(year),
      plateNumber,
      dailyRate: Number(dailyRate),
      categoryId: Number(categoryId),
      categoryName: categoryName,
    });

    navigate("/vehicles");
  };

  return (
    <div className="p-6 max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6">Edit Vehicle</h1>

      <form onSubmit={handleSubmit}>
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
        <div className="mb-4">
          <label className="block text-sm font-medium mb-1">Category</label>
          <select
            value={categoryName}
            onChange={(e) => {
              setCategoryName(e.target.value);
              const selected = categories.find(
                (c) => c.name === e.target.value,
              );
              if (selected) setCategoryId(selected.categoryId.toString());
            }}
            className="w-full border rounded-lg px-3 py-2"
          >
            <option value="">Select Category</option>
            {categories.map((cat) => (
              <option key={cat.categoryId} value={cat.name}>
                {cat.name}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-4"></div>
        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 "
        >
          Update Vehicle
        </button>
      </form>
    </div>
  );
}
