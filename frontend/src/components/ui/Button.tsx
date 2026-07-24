import type { ButtonHTMLAttributes } from 'react';

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'secondary';
  isLoading?: boolean;
}

export function Button({ variant = 'primary', isLoading, children, ...props }: ButtonProps) {
  const base = 'w-full py-2 px-4 rounded-lg font-medium transition-colors disabled:opacity-50';
  const variants = {
    primary: 'bg-blue-600 text-white hover:bg-blue-700',
    secondary: 'bg-gray-200 text-gray-800 hover:bg-gray-300',
  };

  return (
    <button {...props} disabled={isLoading || props.disabled} className={`${base} ${variants[variant]}`}>
      {isLoading ? 'Loading...' : children}
    </button>
  );
}
