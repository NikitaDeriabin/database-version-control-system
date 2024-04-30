export interface UserProfileDto {
    userName: string;
    firstName: string;
    lastName: string;
    avatarUrl: string;
    DBGuardNotification: boolean;
    emailNotification: boolean;
    isGoogleAuth: boolean;
}
