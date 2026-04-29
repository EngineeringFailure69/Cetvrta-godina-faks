#define _CRT_SECURE_NO_WARNINGS
#define MSMPI_NO_DEPRECATE_20
#include<stdio.h>
#include<mpi.h>
#include<stdlib.h>

#define N 4

void printFile(char filePath[], int size)
{
	FILE* f = fopen(filePath, "rb");
	int total = size * N;
	char* buf = (char*)malloc(total * sizeof(char));

	fread(buf, sizeof(char), total, f);
	fclose(f);

	for (int i = 0; i < total; i++)
		printf("%c", buf[i]);
	printf("\n");

	free(buf);
}

int main(int argc, char* argv[])
{
	int rank, size;
	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);
	MPI_File file1, file2;
	MPI_Offset offset = (MPI_Offset)(size - 1 - rank) * N * sizeof(char);
	char path1[] = "file1.dat";
	char path2[] = "file2.dat";
	char text[N] = "ni";
	text[N - 2] = rank + '0';

	//A)
	MPI_File_open(MPI_COMM_WORLD, path1, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &file1);
	MPI_File_seek(file1, offset, MPI_SEEK_SET);
	MPI_File_write(file1, text, N, MPI_CHAR, MPI_STATUS_IGNORE);
	MPI_File_close(&file1);
	MPI_Barrier(MPI_COMM_WORLD);
	/*if (rank == 0)
		printFile(path1, size);*/
	
	//B)
	char read[N];
	MPI_File_open(MPI_COMM_WORLD, path1, MPI_MODE_RDONLY, MPI_INFO_NULL, &file1);
	MPI_File_read_shared(file1, read, N, MPI_CHAR, MPI_STATUS_IGNORE);
	MPI_File_close(&file1);
	MPI_Barrier(MPI_COMM_WORLD);
	//printf("%d_", rank);
	//for (int i = 0; i < N; i++)
	//{
	//	printf("%c", read[i]);
	//}

	//C)
	MPI_Datatype vector;
	int blockLength = N / size;
	int stride = N;
	int displacement = N / size * rank;
	MPI_Type_vector(N, blockLength, stride, MPI_CHAR, &vector);
	MPI_Type_commit(&vector);
	MPI_File_open(MPI_COMM_WORLD, path2, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &file2);
	MPI_File_set_view(file2, displacement, MPI_CHAR, vector, "native", MPI_INFO_NULL);
	MPI_File_write_all(file2, read, N, MPI_CHAR, MPI_STATUS_IGNORE);
	MPI_Barrier(MPI_COMM_WORLD);
	MPI_File_close(&file2);
	if (rank == 0)
		printFile(path2, size);

	MPI_Finalize();
	return 0;
}