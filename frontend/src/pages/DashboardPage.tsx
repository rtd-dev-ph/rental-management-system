import { useAuth } from "../hooks/useAuth";
import { Link } from "react-router-dom";

export function DashboardPage() {
  const { user, logout } = useAuth();

  return (
    <div className="min-h-screen bg-gray-100 p-8">
      <div className="max-w-4xl mx-auto">
        {/* Header */}
        <div className="flex justify-between items-center mb-8">
          <h1 className="text-2xl font-bold">Dashboard</h1>
          <button
            onClick={logout}
            className="bg-red-600 text-white px-4 py-2 rounded-lg hover:bg-red-700"
          >
            Sign Out
          </button>
        </div>

        {/* Welcome */}
        <div className="bg-white rounded-xl shadow-md p-6 mb-6">
          <p className="text-lg">
            Welcome,{" "}
            <span className="font-bold">
              {user?.firstName} {user?.lastName}
            </span>
            !
          </p>
          <p className="text-gray-600">Role: {user?.role}</p>
        </div>

        {/* Navigation Cards */}
        <div className="grid grid-cols-2 gap-6">
          <Link
            to="/vehicles"
            className="bg-white rounded-xl shadow-md p-8 hover:shadow-lg transition-shadow"
          >
            <div className="text-4xl mb-4">🏍️</div>
            <h2 className="text-xl font-bold mb-2">Vehicles</h2>
            <p className="text-gray-600">Manage your vehicle fleet</p>
          </Link>

          <Link
            to="/vehicles/new"
            className="bg-white rounded-xl shadow-md p-8 hover:shadow-lg transition-shadow"
          >
            <div className="text-4xl mb-4">➕</div>
            <h2 className="text-xl font-bold mb-2">Add Vehicle</h2>
            <p className="text-gray-600">Register a new vehicle</p>
          </Link>

          <Link
            to="/reservations"
            className="bg-white rounded-xl shadow-md p-8 hover:shadow-lg transition-shadow"
          >
            <div className="text-4xl mb-4">📅</div>
            <h2 className="text-xl font-bold mb-2">Reservations</h2>
            <p className="text-gray-600">View all bookings</p>
          </Link>

          <Link
            to="/reservations/new"
            className="bg-white rounded-xl shadow-md p-8 hover:shadow-lg transition-shadow"
          >
            <div className="text-4xl mb-4">📝</div>
            <h2 className="text-xl font-bold mb-2">New Reservation</h2>
            <p className="text-gray-600">Create a booking</p>
          </Link>
        </div>
      </div>
    </div>
  );
}
