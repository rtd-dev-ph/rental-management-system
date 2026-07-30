import { useState, useCallback, type ReactNode } from 'react';
import { AuthContext } from './AuthContext';
import type { AuthResponse, LoginRequest, RegisterRequest } from '../types/auth';
import { authService } from '../services/authService';

function getStoredUser(): AuthResponse | null {
  const token = localStorage.getItem('accessToken');
  const userData = localStorage.getItem('user');
  if (token && userData) {
    return JSON.parse(userData);
  }
  return null;
}

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<AuthResponse | null>(getStoredUser);

  const saveAuth = useCallback((data: AuthResponse) => {
    localStorage.setItem('accessToken', data.accessToken);
    localStorage.setItem('refreshToken', data.refreshToken);
    localStorage.setItem('user', JSON.stringify(data));
    setUser(data);
  }, []);

  const login = useCallback(async (data: LoginRequest) => {
    const response = await authService.login(data);
    saveAuth(response);
  }, [saveAuth]);

  const register = useCallback(async (data: RegisterRequest) => {
    const response = await authService.register(data);
    saveAuth(response);
  }, [saveAuth]);

  const logout = useCallback(() => {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('user');
    setUser(null);
  }, []);

  return (
    <AuthContext.Provider value={{ user, login, register, logout, isAuthenticated: !!user }}>
      {children}
    </AuthContext.Provider>
  );
}
