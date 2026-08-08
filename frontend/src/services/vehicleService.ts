import api from "./api";

export interface Vehicle {
  id: string;
  brand: string;
  model: string;
  year: number;
  plateNumber: string;
  dailyRate: number;
  status: string;
  categoryId: number;
}

export async function getVehicles(): Promise<Vehicle[]> {
  const response = await api.get<Vehicle[]>("/Vehicle");
  return response.data;
}

export async function createVehicle(data: {
  brand: string;
  model: string;
  year: number;
  plateNumber: string;
  dailyRate: number;
  categoryId: number;
}) {
  const response = await api.post("/vehicle", data);
  return response.data;
}
