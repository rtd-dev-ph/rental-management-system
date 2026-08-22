import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import api from "../../services/api";
import type { Vehicle } from "../../services/vehicleService";

export function CreateReservationPage() {
  const navigate = useNavigate();
  const [vehicles, setVehicles] = useState<Vehicle[]>([]);
  const [vehicleId, setVehicleId] = useState("");
  // const [customerId, setCustomerId] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [totalAmount, setTotalAmount] = useState("");
  const [dailyRate, setDailyRate] = useState(0);

  useEffect(() => {
    async function loadVehicles() {
      const response = await api.get("/vehicle");

      const data = response.data.data || response.data;

      setVehicles(data.filter((x: Vehicle) => x.status === "Available"));
    }
    loadVehicles();
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const user = JSON.parse(localStorage.getItem("user") || "{}");

    await api.post("/reservation", {
      vehicleId,
      customerId: user.userId,
      startDate: new Date(startDate).toISOString(),
      endDate: new Date(endDate).toISOString(),
      totalAmount: Number(totalAmount),
    });

    navigate("/reservations");
  };

  const handleVehicleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedId = e.target.value;
    setVehicleId(selectedId);

    const selected = vehicles.find((x: Vehicle) => x.id === selectedId);
    if (selected) {
      setDailyRate(selected.dailyRate);
    }
  };

  const calculateTotal = (start: string, end: string) => {
    if (!start || !end || !dailyRate) return;
    const startDate = new Date(start);
    const endDate = new Date(end);
    const days = Math.ceil(
      (endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24),
    );

    if (days > 0) {
      setTotalAmount((days * dailyRate).toString());
    }
  };

  return (
    <div className="p-6 max-w-lg mx-auto">
      <h1 className="text-2xl font-bold mb-6">New Reservation</h1>

      <form onSubmit={handleSubmit}>
        <div className="mb-4">
          <label htmlFor="" className="block text-sm font-medium mb-1">
            Vehicle
          </label>
          <select
            value={vehicleId}
            // onChange={(e) => setVehicleId(e.target.value)}
            onChange={handleVehicleChange}
            className="w-full border rounded-lg px-3 py-2"
          >
            <option value="">Select Vehicle</option>
            {vehicles.map((x: Vehicle) => (
              <option value={x.id} key={x.id}>
                {x.brand} {x.model}-{x.plateNumber}(₱{x.dailyRate}/day)
              </option>
            ))}
          </select>
        </div>

        <div className="mb-4">
          <label htmlFor="" className="block text-sm font-medium mb-1">
            Start Date
          </label>
          <input
            type="datetime-local"
            value={startDate}
            onChange={(e) => {
              setStartDate(e.target.value);
              calculateTotal(e.target.value, endDate);
            }}
            className="w-full border rounded-lg px-3 py-2"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="" className="block text-sm font-medium mb-1">
            End Date{" "}
          </label>
          <input
            type="datetime-local"
            value={endDate}
            onChange={(e) => {
              setEndDate(e.target.value);
              calculateTotal(startDate, e.target.value);
            }}
            className="w-full border rounded-lg px-3 py-2"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="" className="block text-sm font-medium mb-1">
            Total Amount (₱)
          </label>
          <input
            type="number"
            value={totalAmount}
            disabled
            onChange={(e) => setTotalAmount(e.target.value)}
            className="w-full border rounded-lg px-3 py-2 bg-gray-200 cursor-not-allowed"
          />
        </div>
        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700"
        >
          Create Reservation
        </button>
      </form>
    </div>
  );
}
