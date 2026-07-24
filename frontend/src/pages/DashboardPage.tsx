import { useAuth } from '../hooks/useAuth';

export function DashboardPage() {
  const { user, logout } = useAuth();

  return (
    <div className="min-h-screen bg-gray-100 p-8">
      <div className="max-w-2xl mx-auto bg-white rounded-xl shadow-md p-8">
        <h1 className="text-2xl font-bold mb-4">Dashboard</h1>
        <p className="text-gray-600 mb-2">Welcome, {user?.firstName} {user?.lastName}!</p>
        <p className="text-gray-600 mb-2">Email: {user?.email}</p>
        <p className="text-gray-600 mb-4">Role: {user?.role}</p>
        <button onClick={logout} className="bg-red-600 text-white px-4 py-2 rounded-lg hover:bg-red-700">
          Sign Out
        </button>
      </div>
    </div>
  );
}
