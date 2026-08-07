#!/bin/bash

# Kill any existing processes on dev ports
echo "🧹 Cleaning up old processes..."
pkill -f "dotnet run.*RMS.Api" 2>/dev/null
pkill -f "npm run dev" 2>/dev/null
kill -9 $(lsof -t -i:5173) 2>/dev/null
kill -9 $(lsof -t -i:5008) 2>/dev/null

echo "🐳 Starting PostgreSQL..."
docker compose up -d

echo "⏳ Waiting for database..."
sleep 5

echo "🚀 Starting API..."
dotnet run --project src/RMS.Api --launch-profile http &
API_PID=$!

echo "🎨 Starting Frontend on fixed port 5173..."
cd frontend && npm run dev -- --port 5173 &
FRONTEND_PID=$!

sleep 3

echo ""
echo "✅ Everything is running!"
echo "   API:      http://localhost:5008/swagger"
echo "   Frontend: http://localhost:5173"
echo ""
echo "Press Ctrl+C to stop all services"

trap "echo 'Stopping...'; kill $API_PID $FRONTEND_PID 2>/dev/null; docker compose down; exit" INT
wait