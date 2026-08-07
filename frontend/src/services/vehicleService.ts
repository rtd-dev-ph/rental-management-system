import api from "./api";

export interface Vehicle {
  id: string;
  brand: string;
  model: string;
  year: number;
  plateNumber: string;
  dailyRate: number;
  status: string;
  categoryName: string;
}

export async function getVehicles(): Promise<Vehicle[]> {
  const response = await api.get<Vehicle[]>("/Vehicle");
  return response.data;
}
