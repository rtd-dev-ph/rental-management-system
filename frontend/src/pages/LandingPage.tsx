import { useEffect, useState } from "react";
import api from "../services/api";
import { Link } from "react-router-dom";

interface Vehicle {
  id: string;
  brand: string;
  model: string;
  year: number;
  plateNumber: string;
  dailyRate: number;
  status: string;
  categoryName?: string;
  imageUrl?: string;
}

export function LandingPage() {
  const [vehicles, setVehicles] = useState<Vehicle[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadVehicles() {
      const response = await api.get("/vehicle");
      const data = response.data.data || response.data;
      setVehicles(data);
      setLoading(false);
    }
    loadVehicles();
  }, []);

  if (loading) return <div className="p-8">Loading vehicles...</div>;

  const available = vehicles.filter((v) => v.status === "Available");

  return (
    <div className="min-h-screen bg-gray-50">
      {/* Hero Section */}
      <div className="bg-blue-600 text-white py-16">
        <div className="max-w-6xl mx-auto px-6 text-center">
          <h1 className="text-4xl font-bold mb-4">Rent Your Ride</h1>
          <p className="text-xl text-blue-100">
            Quality vehicles at affordable rates
          </p>
        </div>
      </div>

      {/* Available Vehicles Grid */}
      <div className="max-w-6xl mx-auto px-6 py-12">
        <h2 className="text-2xl font-bold mb-8">Available Vehicles</h2>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {available.map((vehicle) => (
            <div
              key={vehicle.id}
              className="bg-white rounded-xl shadow-md overflow-hidden hover:shadow-lg transition-shadow"
            >
              {/* Vehicle Image */}
              <div className="h-48 bg-gray-200 flex items-center justify-center">
                {vehicle.imageUrl ? (
                  <img
                    src={`http://localhost:5008${vehicle.imageUrl}`}
                    alt={`${vehicle.brand} ${vehicle.model}`}
                    className="w-full h-full object-cover"
                  />
                ) : (
                  <span className="text-5xl">🏍️</span>
                )}
              </div>

              {/* Vehicle Info */}
              <div className="p-6">
                <h3 className="text-xl font-bold mb-2">
                  {vehicle.brand} {vehicle.model}
                </h3>
                <p className="text-gray-600 mb-1">
                  {vehicle.year} • {vehicle.categoryName || "Vehicle"}
                </p>
                <p className="text-gray-600 mb-4">
                  Plate: {vehicle.plateNumber}
                </p>

                <div className="flex items-center justify-between">
                  <span className="text-2xl font-bold text-blue-600">
                    ₱{vehicle.dailyRate}
                    <span className="text-sm text-gray-500">/day</span>
                  </span>
                  <span className="bg-green-100 text-green-800 px-3 py-1 rounded-full text-sm font-medium">
                    Available
                  </span>
                </div>
                <Link
                  to={`/reservations/new?vehicleId=${vehicle.id}`}
                  className="mt-4 w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 text-center block"
                >
                  Book Now
                </Link>
              </div>
            </div>
          ))}
        </div>
        {available.length === 0 && (
          <div className="text-center py-12">
            <p className="text-gray-500">
              No vehicles available at the moment.
            </p>
          </div>
        )}
      </div>
    </div>
  );
}
