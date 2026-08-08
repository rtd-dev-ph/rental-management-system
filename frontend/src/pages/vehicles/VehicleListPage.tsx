// frontend/src/pages/vehicles/VehicleListPage.tsx

// WHAT: Imports bring in code from other files
// WHY: We need React functions, our API service, and navigation
import { useState, useEffect } from "react";
import { getVehicles, type Vehicle } from "../../services/vehicleService";
import { Link } from "react-router-dom";

export function VehicleListPage() {
  // ─── STATE ───────────────────────────
  // WHAT: useState = "React, remember this for me"
  // WHY: When these values change, React rebuilds the UI automatically
  // HOW: [variable, setter function] = useState(initial value)

  // vehicles: starts as empty array [], will be filled with API data
  const [vehicles, setVehicles] = useState<Vehicle[]>([]);

  // loading: true while fetching, false when done
  const [loading, setLoading] = useState(true);

  // error: null if no error, string if something went wrong
  const [error, setError] = useState<string | null>(null);

  // ─── FETCH DATA ──────────────────────
  // WHAT: useEffect = "Run this code after the component appears"
  // WHY: We want to load data when the page first opens
  // HOW: useEffect(callback, [dependencies])
  //      Empty [] = run once (like Form_Load in WinForms)

  useEffect(() => {
    // WHAT: async function inside useEffect
    // WHY: useEffect can't be async directly
    async function loadVehicles() {
      try {
        setLoading(true); // Show loading spinner
        const data = await getVehicles(); // Call API
        setVehicles(data); // Save vehicles to state
        setError(null); // Clear any old errors
      } catch (err) {
        setError("Failed to load vehicles"); // Show error
        console.error(err);
      } finally {
        setLoading(false); // Hide loading spinner
      }
    }

    loadVehicles(); // Call the function
  }, []); // Empty array = run once when page loads

  // ─── CONDITIONAL RENDERING ───────────
  // WHAT: Different UI based on state
  // WHY: Users need feedback (loading, error, empty, data)

  // State 1: Loading
  if (loading) {
    return (
      <div className="flex justify-center items-center h-64">
        <p className="text-gray-500">Loading vehicles...</p>
      </div>
    );
  }

  // State 2: Error
  if (error) {
    return (
      <div className="bg-red-50 border border-red-400 text-red-700 px-4 py-3 rounded">
        {error}
      </div>
    );
  }

  // State 3: Empty
  if (vehicles.length === 0) {
    return (
      <div className="text-center py-12">
        <p className="text-gray-500">No vehicles found.</p>
        <Link to="/vehicles/new" className="text-blue-600 hover:underline">
          Add your first vehicle
        </Link>
      </div>
    );
  }

  // State 4: Data loaded - show the table
  return (
    <div className="p-6">
      {/* Header */}
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold">Vehicles</h1>
        <Link
          to="/vehicles/new"
          className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700"
        >
          Add Vehicle
        </Link>
      </div>

      {/* Table */}
      <div className="bg-white rounded-lg shadow overflow-hidden">
        <table className="w-full">
          {/* Table Header */}
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Brand
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">



                
                Model
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Year
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Plate
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Rate/Day
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Status
              </th>
            </tr>
          </thead>

          {/* Table Body */}
          <tbody className="divide-y divide-gray-200">
            {vehicles.map((vehicle) => (
              <tr key={vehicle.id} className="hover:bg-gray-50">
                <td className="px-6 py-4">{vehicle.brand}</td>
                <td className="px-6 py-4">{vehicle.model}</td>
                <td className="px-6 py-4">{vehicle.year}</td>
                <td className="px-6 py-4">{vehicle.plateNumber}</td>
                <td className="px-6 py-4">₱{vehicle.dailyRate}</td>
                <td className="px-6 py-4">
                  <StatusBadge status={vehicle.status} />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

// WHAT: A small reusable component for status
// WHY: Status needs different colors
function StatusBadge({ status }: { status: string }) {
  const colors: Record<string, string> = {
    Available: "bg-green-100 text-green-800",
    Rented: "bg-blue-100 text-blue-800",
    Maintenance: "bg-yellow-100 text-yellow-800",
    Archived: "bg-red-100 text-red-800",
  };

  return (
    <span
      className={`px-2 py-1 rounded-full text-xs font-medium ${colors[status] || "bg-gray-100"}`}
    >
      {status}
    </span>
  );
}
