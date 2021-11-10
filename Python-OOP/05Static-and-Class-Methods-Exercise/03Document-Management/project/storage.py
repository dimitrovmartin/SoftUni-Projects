class Storage:
    def __init__(self):
        self.categories = []
        self.topics = []
        self.documents = []

    def add_category(self, category):
        if category not in self.categories:
            self.categories.append(category)

    def add_topic(self, topic):
        if topic not in self.topics:
            self.topics.append(topic)

    def add_document(self, document):
        if document not in self.documents:
            self.documents.append(document)

    def edit_category(self, category_id, new_name):
        category = self.__find_object_by_id(category_id, self.categories)

        if category:
            category.name = new_name

    def edit_topic(self, topic_id, new_topic, new_storage_folder):
        topic = self.__find_object_by_id(topic_id, self.topics)

        if topic:
            topic.topic = new_topic
            topic.storage_folder = new_storage_folder

    def edit_document(self, document_id, new_file_name):
        document = self.__find_object_by_id(document_id, self.documents)

        if document:
            document.file_name = new_file_name

    def delete_category(self, category_id):
        category = self.__find_object_by_id(category_id, self.categories)

        if category:
            self.categories.remove(category)

    def delete_topic(self, topic_id):
        topic = self.__find_object_by_id(topic_id, self.topics)

        if topic:
            self.topics.remove(topic)

    def delete_document(self, document_id):
        document = self.__find_object_by_id(document_id, self.documents)

        if document:
            self.documents.remove(document)

    def get_document(self, document_id):
        document = self.__find_object_by_id(document_id, self.documents)

        if document:
            return document

    def __repr__(self):
        info = '\n'.join(str(x) for x in self.documents)

        return info

    @staticmethod
    def __find_object_by_id(_id, objects):
        obj = [x for x in objects if x.id == _id]
        return obj[0] if obj else None
