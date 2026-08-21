import { useState, useEffect } from "react";
import api from "../../services/api";

interface Reservation {
  reservationId: string;
  customerId: string;
  startDate: string;
  endDate: string;
  status: string;
  totalAmount: number;
  notes: string;
  createdAt: string;
  updatedAt: string;
}

export function ReservationListPage() {
  const [reservations, setReservations] = useState<Reservation[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadReservation() {
      const response = await api.get("/reservation");
      const data = response.data.data || response.data;
      setReservations(data);
      setLoading(false);
    }
    loadReservation();
  }, []);

  if (loading) return <div className="p-6">Loading reservations...</div>;

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-6">Reservations</h1>

      <div className="bg-white rounded-lg shadow overflow-hidden">
        <table className="w-full">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Start Date
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                End Date
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Amount
              </th>
              <th className="px-6 py-3 text-left text-sm font-medium text-gray-500">
                Status
              </th>
            </tr>
          </thead>
          <tbody className="divide-y divide-gray-200">
            {reservations.map((r) => (
              <tr key={r.reservationId}>
                <td className="px-6 py-4">
                  {new Date(r.startDate).toLocaleDateString()}
                </td>
                <td className="px-6 py-4">
                  {new Date(r.endDate).toLocaleDateString()}
                </td>
                <td className="px-6 py-4">₱{r.totalAmount}</td>
                <td className="px-6 py-4">{r.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
