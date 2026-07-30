interface AlertProps {
  message: string;
  type?: 'error' | 'success';
}

export function Alert({ message, type = 'error' }: AlertProps) {
  const styles = {
    error: 'bg-red-50 border-red-400 text-red-700',
    success: 'bg-green-50 border-green-400 text-green-700',
  };

  return (
    <div className={`border px-4 py-3 rounded-lg mb-4 ${styles[type]}`}>
      {message}
    </div>
  );
}
