import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider } from "./contexts/AuthProvider";
import { LoginPage } from "./pages/LoginPage";
import { RegisterPage } from "./pages/RegisterPage";
import { DashboardPage } from "./pages/DashboardPage";
import { ProtectedRoute } from "./components/auth/ProtectedRoute";
import { VehicleListPage } from "./pages/vehicles/VehicleListPage";
import { CreateVehiclePage } from "./pages/vehicles/CreateVehiclePage";
import { EditVehiclePage } from "./pages/vehicles/EditVehiclePage";
import { CreateReservationPage } from "./pages/reservations/CreateReservationPage";
import { ReservationListPage } from "./pages/reservations/ReservationListPage";

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route
            path="/dashboard"
            element={
              <ProtectedRoute>
                <DashboardPage />
              </ProtectedRoute>
            }
          />
          <Route path="*" element={<Navigate to="/login" />} />
          <Route
            path="/vehicles"
            element={
              <ProtectedRoute>
                <VehicleListPage />
              </ProtectedRoute>
            }
          />
          <Route
            path="/vehicles/new"
            element={
              <ProtectedRoute>
                <CreateVehiclePage />
              </ProtectedRoute>
            }
          />
          <Route
            path="/vehicles/:id/edit"
            element={
              <ProtectedRoute>
                <EditVehiclePage />
              </ProtectedRoute>
            }
          />
          <Route
            path="/reservations/new"
            element={
              <ProtectedRoute>
                <CreateReservationPage />
              </ProtectedRoute>
            }
          >
            {" "}
          </Route>
          <Route
            path="/reservations"
            element={
              <ProtectedRoute>
                <ReservationListPage />
              </ProtectedRoute>
            }
          />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
